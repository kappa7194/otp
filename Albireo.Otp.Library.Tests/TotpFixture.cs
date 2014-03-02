namespace Albireo.Otp.Library.Tests
{
    using System.Text;

    public class TotpFixture
    {
        public TotpFixture()
        {
            this.Totp = new Totp(Base32.ToString(Encoding.UTF8.GetBytes("12345678901234567890")), digits: 8);
        }

        public Totp Totp { get; private set; }
    }
}
