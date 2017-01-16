namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>Time-based one-time password algorithm implementation.</summary>
    public static class Totp
    {
        private const int DefaultPeriod = 30;

        /// <summary>Compute the one-time code for the given parameters.</summary>
        /// <param name="algorithm">The hashing algorithm for the HMAC computation.</param>
        /// <param name="secret">The ASCII-encoded base32-encoded shared secret.</param>
        /// <param name="datetime">The date with time for which the one-time code must be computed.</param>
        /// <param name="digits">The number of digits of the one-time codes.</param>
        /// <param name="period">The period step used for the HMAC counter computation.</param>
        /// <returns>The one-time code for the given date.</returns>
        public static int GetCode(
            HashAlgorithm algorithm,
            string secret,
            DateTime datetime,
            int digits = Otp.DefaultDigits,
            int period = Totp.DefaultPeriod)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(HashAlgorithm), algorithm));
            Contract.Requires<ArgumentOutOfRangeException>(algorithm != HashAlgorithm.Unknown);
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentNullException>(datetime != null);
            Contract.Requires<ArgumentException>(Enum.IsDefined(typeof(DateTimeKind), datetime.Kind));
            Contract.Requires<ArgumentException>(datetime.Kind != DateTimeKind.Unspecified);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Requires<ArgumentOutOfRangeException>(period > 0);
            Contract.Ensures(Contract.Result<int>() > 0);
            Contract.Ensures(Contract.Result<int>() < Math.Pow(10, digits));

            datetime = datetime.Kind == DateTimeKind.Utc ? datetime : datetime.ToUniversalTime();

            var unixTime = datetime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            var counter = (long) (unixTime * 1000) / (period * 1000);

            return Otp.GetCode(algorithm, secret, counter, digits);
        }

        /// <summary>Build a URI for secret key provisioning.</summary>
        /// <param name="algorithm">The hashing algorithm for the HMAC computation.</param>
        /// <param name="issuer">The name of the entity issuing and maintaining the key.</param>
        /// <param name="account">The account name for which the one-time codes will work.</param>
        /// <param name="secret">The ASCII-encoded base32-encoded shared secret.</param>
        /// <param name="period">The period step for the HMAC counter computation.</param>
        /// <param name="digits">The number of digits of the one-time codes.</param>
        /// <returns>The provisioning URI.</returns>
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
