namespace Albireo.Otp.Library.Tests
{
    using System.Text;

    public class HotpFixture
    {
        public HotpFixture()
        {
            this.Hotp = new Hotp(Base32.ToString(Encoding.UTF8.GetBytes("12345678901234567890")));
        }

        public Hotp Hotp { get; set; }
    }
}
