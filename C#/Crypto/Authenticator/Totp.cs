using System;

namespace Authenticator
{
    public class Totp : Hotp
    {
        public Totp() : base() { }

        public Totp(string sharedSecret) : base(sharedSecret) { }

        public int GetOtp()
        {
            var epoch_time = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return GetOtp((ulong)Math.Floor(epoch_time / 30));
        }
    }
}
