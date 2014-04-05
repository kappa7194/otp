namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    public static class Totp
    {
        private const int DefaultInterval = 30;

        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static int GetCode(string secret, DateTime date, int digits = Otp.DefaultDigits, int interval = DefaultInterval)
        {
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentNullException>(date != null);
            Contract.Requires<ArgumentOutOfRangeException>(date >= Epoch);
            Contract.Requires<ArgumentException>(Enum.IsDefined(typeof(DateTimeKind), date.Kind));
            Contract.Requires<ArgumentException>(date.Kind != DateTimeKind.Unspecified);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Requires<ArgumentOutOfRangeException>(interval > 0);
            Contract.Ensures(Contract.Result<int>() > 0);
            Contract.Ensures(Contract.Result<int>() < Math.Pow(10, digits));
            date = date.Kind == DateTimeKind.Utc ? date : date.ToUniversalTime();
            return Otp.GetCode(secret, (long) (date.Subtract(Epoch).TotalSeconds * 1000) / (interval * 1000), digits);
        }

        public static string GetKeyUri(
            string issuer,
            string account,
            byte[] secret,
            int digits = Otp.DefaultDigits,
            int interval = Totp.DefaultInterval)
        {
            Contract.Requires<ArgumentNullException>(issuer != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(issuer));
            Contract.Requires<ArgumentNullException>(account != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(account));
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentException>(secret.Length > 0);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Requires<ArgumentOutOfRangeException>(interval > 0);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

            return
                Otp.GetKeyUri(
                    OtpType.Totp,
                    issuer,
                    account,
                    secret,
                    HashAlgorithm.Sha1,
                    digits,
                    0,
                    interval);
        }
    }
}
