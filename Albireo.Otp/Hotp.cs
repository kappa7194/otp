namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    public static class Hotp
    {
        public static int GetCode(string secret, long counter, int digits = Otp.DefaultDigits)
        {
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentOutOfRangeException>(counter >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Ensures(Contract.Result<int>() > 0);
            Contract.Ensures(Contract.Result<int>() < Math.Pow(10, digits));
            return Otp.GetCode(secret, counter, digits);
        }

        public static string GetKeyUri(
            string issuer,
            string account,
            byte[] secret,
            long counter,
            int digits = Otp.DefaultDigits)
        {
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
                    HashAlgorithm.Sha1,
                    digits,
                    counter,
                    0);
        }
    }
}
