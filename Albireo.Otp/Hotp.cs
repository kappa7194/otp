namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    public static class Hotp
    {
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
