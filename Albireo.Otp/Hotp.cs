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
    }
}
