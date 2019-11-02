using System;
using Authenticator;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            var totp = new Authenticator.Totp();
            Console.WriteLine(totp.GetOtp());
        }
    }
}
