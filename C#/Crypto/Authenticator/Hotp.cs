using System;
using System.Security.Cryptography;

namespace Authenticator
{
    public class Hotp
    {
        public Hotp()
        {
            using (var generator = new RNGCryptoServiceProvider())
            using (var hmac = HMAC.Create("HMACSHA1"))
            {
                sharedSecret = new byte[hmac.HashSize / 8];
                generator.GetBytes(sharedSecret);
            }
        }

        public Hotp(string sharedSecret)
        {
            this.sharedSecret = Base32.ToByteArray(sharedSecret);
        }

        public string GetSharedSecret()
        {
            return Base32.ToBase32String(sharedSecret);
        }

        public int GetOtp(ulong count, int digits = 6)
        {
            using (var hmac = HMAC.Create("HMACSHA1"))
            {
                hmac.Key = sharedSecret;
                hmac.ComputeHash(BitConverter.GetBytes(count));
                return Truncate(hmac.Hash, digits);
            }
        }

        private static int Truncate(byte[] hmacResult, int digits)
        {
            var truncated = DynamicTruncation(hmacResult);
            return truncated % (int)Math.Pow(10, digits);
        }

        private static int DynamicTruncation(byte[] hmac_result)
        {
            int offset = hmac_result[19] & 0xf;
            int bin_code = (hmac_result[offset] & 0x7f) << 24
               | (hmac_result[offset + 1] & 0xff) << 16
               | (hmac_result[offset + 2] & 0xff) << 8
               | (hmac_result[offset + 3] & 0xff);
            return bin_code;
        }

        private readonly byte[] sharedSecret;
    }
}
