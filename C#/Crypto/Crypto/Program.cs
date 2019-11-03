using System;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            var totp = new Authenticator.Totp();
            Console.WriteLine($"Secret key : {totp.SharedSecret}\nOTP : {totp.GetOtp()}");
        }
    }
}
