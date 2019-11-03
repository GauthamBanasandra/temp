using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

namespace Authenticator
{
    public class Hotp
    {
        private readonly byte[] sharedSecret;
        public string SharedSecret
        {
            get
            {
                return Base32.ToBase32String(sharedSecret);
            }
        }

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

        public int GetOtp(long count, int digits = 6)
        {
            using (var hmac = HMAC.Create("HMACSHA1"))
            {
                hmac.Key = sharedSecret;
                hmac.ComputeHash(StringToByteArray(count.ToString("X16", CultureInfo.InvariantCulture)));
                return Truncate(hmac.Hash, digits);
            }
        }

        private static int Truncate(byte[] hmacResult, int digits)
        {
            var truncated = DynamicTruncation(hmacResult);
            return truncated % (int)Math.Pow(10, digits);
        }

        private static int DynamicTruncation(byte[] hmacResult)
        {
            int offset = hmacResult.Last() & 0x0f;
            int code = (hmacResult[offset] & 0x7f) << 24
               | (hmacResult[offset + 1] & 0xff) << 16
               | (hmacResult[offset + 2] & 0xff) << 8
               | (hmacResult[offset + 3] & 0xff);
            return code;
        }

        private static byte[] StringToByteArray(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
