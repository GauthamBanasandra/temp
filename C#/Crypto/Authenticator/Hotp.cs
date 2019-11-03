using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        public string SharedSecret
        {
            get
            {
                return Base32.ToBase32String(sharedSecret);
            }
        }

        public int GetOtp(long count, int digits = 6)
        {
            using (var hmac = HMAC.Create("HMACSHA1"))
            {
                hmac.Key = sharedSecret;
                hmac.ComputeHash(StringToByteArray(count.ToString("X16")));
                return Truncate(hmac.Hash, digits);
            }
        }

        private static int Truncate(byte[] hmac_result, int digits)
        {
            var truncated = DynamicTruncation(hmac_result);
            return truncated % (int)Math.Pow(10, digits);
        }

        private static int DynamicTruncation(byte[] hmac_result)
        {
            int offset = hmac_result.Last() & 0x0f;
            int bin_code = (hmac_result[offset] & 0x7f) << 24
               | (hmac_result[offset + 1] & 0xff) << 16
               | (hmac_result[offset + 2] & 0xff) << 8
               | (hmac_result[offset + 3] & 0xff);
            return bin_code;
        }

        private static byte[] StringToByteArray(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private readonly byte[] sharedSecret;
    }
}
