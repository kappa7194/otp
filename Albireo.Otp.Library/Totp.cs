namespace Albireo.Otp.Library
{
    using System;

    public static class Totp
    {
        private const int DefaultInterval = 30;

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static int GetCode(string secret, DateTime date, int digits = Otp.DefaultDigits, int interval = DefaultInterval)
        {
            date = date.Kind == DateTimeKind.Utc ? date : date.ToUniversalTime();
            return Otp.GetCode(secret, (long) (date.Subtract(Epoch).TotalSeconds * 1000) / (interval * 1000), digits);
        }
    }
}
