using System;
using Authenticator;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            var totp = new Authenticator.Totp("JBSWY3DPEHPK3PXP");
            Console.WriteLine($"Secret key : {totp.GetSharedSecret()}\nOTP : {totp.GetOtp()}");
        }
    }
}
