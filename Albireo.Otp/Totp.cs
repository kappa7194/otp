namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    public static class Totp
    {
        private const int DefaultPeriod = 30;

        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static int GetCode(
            HashAlgorithm algorithm,
            string secret,
            DateTime date,
            int digits = Otp.DefaultDigits,
            int period = Totp.DefaultPeriod)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(HashAlgorithm), algorithm));
            Contract.Requires<ArgumentOutOfRangeException>(algorithm != HashAlgorithm.Unknown);
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentNullException>(date != null);
            Contract.Requires<ArgumentOutOfRangeException>(date >= Epoch);
            Contract.Requires<ArgumentException>(Enum.IsDefined(typeof(DateTimeKind), date.Kind));
            Contract.Requires<ArgumentException>(date.Kind != DateTimeKind.Unspecified);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Requires<ArgumentOutOfRangeException>(period > 0);
            Contract.Ensures(Contract.Result<int>() > 0);
            Contract.Ensures(Contract.Result<int>() < Math.Pow(10, digits));

            date = date.Kind == DateTimeKind.Utc ? date : date.ToUniversalTime();

            var unixTime = (long) (date.Subtract(Epoch).TotalSeconds * 1000) / (period * 1000);

            return Otp.GetCode(algorithm, secret, unixTime, digits);
        }

        public static string GetKeyUri(
            HashAlgorithm algorithm,
            string issuer,
            string account,
            byte[] secret,
            int digits = Otp.DefaultDigits,
            int period = Totp.DefaultPeriod)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(HashAlgorithm), algorithm));
            Contract.Requires<ArgumentOutOfRangeException>(algorithm != HashAlgorithm.Unknown);
            Contract.Requires<ArgumentNullException>(issuer != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(issuer));
            Contract.Requires<ArgumentNullException>(account != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(account));
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentException>(secret.Length > 0);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Requires<ArgumentOutOfRangeException>(period > 0);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

            return
                Otp.GetKeyUri(
                    OtpType.Totp,
                    issuer,
                    account,
                    secret,
                    algorithm,
                    digits,
                    0,
                    period);
        }
    }
}
