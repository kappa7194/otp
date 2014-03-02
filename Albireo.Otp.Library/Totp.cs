namespace Albireo.Otp.Library
{
    using System;

    public class Totp : Otp
    {
        public const int DefaultInterval = 30;

        private readonly int interval;

        public Totp(string secret, int interval = DefaultInterval, int digits = DefaultDigits) : base(secret, digits)
        {
            this.interval = interval;
        }

        public int GetCode()
        {
            return this.GetCode(DateTime.UtcNow);
        }

        public int GetCode(DateTime utcDate)
        {
            return base.Generate((long) (utcDate.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds * 1000) / (this.interval * 1000));
        }
    }
}
