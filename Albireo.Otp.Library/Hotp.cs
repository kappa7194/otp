namespace Albireo.Otp.Library
{
    public static class Hotp
    {
        public static int GetCode(string secret, long counter, int digits = Otp.DefaultDigits)
        {
            return Otp.GetCode(secret, counter, digits);
        }
    }
}
