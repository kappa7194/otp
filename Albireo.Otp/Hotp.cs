namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>HMAC-based one-time password algorithm implementation.</summary>
    public static class Hotp
    {
        /// <summary>Compute the one-time code for the given parameters.</summary>
        /// <param name="algorithm">The hashing algorithm for the HMAC computation.</param>
        /// <param name="secret">The ASCII-encoded base32-encoded shared secret.</param>
        /// <param name="counter">The counter for which the one-time code must be computed.</param>
        /// <param name="digits">The number of digits of the one-time code.</param>
        /// <returns>The one-time code for the given counter.</returns>
        public static int GetCode(
            HashAlgorithm algorithm,
            string secret,
            long counter,
            int digits = Otp.DefaultDigits)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(HashAlgorithm), algorithm));
            Contract.Requires<ArgumentOutOfRangeException>(algorithm != HashAlgorithm.Unknown);
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentOutOfRangeException>(counter >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Ensures(Contract.Result<int>() > 0);
            Contract.Ensures(Contract.Result<int>() < Math.Pow(10, digits));

            return Otp.GetCode(algorithm, secret, counter, digits);
        }

        /// <summary>Build a URI for secret key provisioning.</summary>
        /// <param name="algorithm">The hashing algorithm for the HMAC computation.</param>
        /// <param name="issuer">The name of the entity issuing and maintaining the key.</param>
        /// <param name="account">The account name for which the one-time codes will work.</param>
        /// <param name="secret">The ASCII-encoded base32-encoded shared secret.</param>
        /// <param name="counter">The initial value for the counter.</param>
        /// <param name="digits">The number of digits of the one-time codes.</param>
        /// <returns>The provisioning URI.</returns>
        public static string GetKeyUri(
            HashAlgorithm algorithm,
            string issuer,
            string account,
            byte[] secret,
            long counter,
            int digits = Otp.DefaultDigits)
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
            Contract.Requires<ArgumentOutOfRangeException>(counter >= 0);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

            return
                Otp.GetKeyUri(
                    OtpType.Hotp,
                    issuer,
                    account,
                    secret,
                    algorithm,
                    digits,
                    counter,
                    0);
        }
    }
}
