using System;

namespace Authenticator
{
    public class Totp : Hotp
    {
        public Totp() : base() { }

        public Totp(string sharedSecret) : base(sharedSecret) { }

        public int GetOtp()
        {
            var epoch_time = Convert.ToInt64(Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds));
            return GetOtp(Convert.ToInt64(epoch_time / 30));
        }
    }
}
