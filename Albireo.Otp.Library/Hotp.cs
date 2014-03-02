namespace Albireo.Otp.Library
{
    public class Hotp : OtpBase
    {
        public Hotp(string secret, int digits = DefaultDigits) : base(secret, digits)
        {
        }

        public int GetCode(long counter)
        {
            return base.Generate(counter);
        }
    }
}
