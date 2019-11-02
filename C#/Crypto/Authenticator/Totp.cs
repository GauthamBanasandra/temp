using System;
using System.Collections.Generic;
using System.Text;

namespace Authenticator
{
    public class Totp : Hotp
    {
        public int GetOtp()
        {
            var epoch_time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return GetOtp((ulong)Math.Floor(epoch_time / 30));
        }
    }
}
