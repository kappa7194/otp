namespace Albireo.Otp.Library
{
    public class Hotp : Otp
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
