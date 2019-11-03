using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Authenticator;

namespace Crypto
{
    class Program
    {
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        static void Main(string[] args)
        {
            //var totp = new Authenticator.Totp("ABCDEFGHIJKLMNOPQRST");
            //Console.WriteLine($"Secret key : {totp.GetSharedSecret()}\nOTP : {totp.GetOtp()}");

            var secret = StringToByteArray("48656c6c6f21deadbeef");
            var time = StringToByteArray("00000000031ff27b");
            var hash = new HMACSHA1(secret).ComputeHash(time);
            Console.WriteLine($"HMAC SHA1 : {ByteArrayToString(hash)}");

            var offset = hash.Last() & 0x0F;
            var otp = (
                ((hash[offset + 0] & 0x7f) << 24) |
                ((hash[offset + 1] & 0xff) << 16) |
                ((hash[offset + 2] & 0xff) << 8) |
                (hash[offset + 3] & 0xff)) % 1000000;
            Console.WriteLine($"OTP : {otp}");
        }
    }
}
