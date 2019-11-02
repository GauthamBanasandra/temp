using System;

namespace Authenticator
{
    public class Totp : Hotp
    {
        public Totp() : base() { }

        public Totp(string sharedSecret) : base(sharedSecret) { }

        public int GetOtp()
        {
            var epoch_time = (DateTime.Now - DateTime.MinValue).TotalSeconds;
            return GetOtp((ulong)Math.Floor(epoch_time / 30));
        }
    }
}
