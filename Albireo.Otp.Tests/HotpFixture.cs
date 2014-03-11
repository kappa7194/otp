namespace Albireo.Otp.Tests
{
    public class HotpFixture
    {
        public HotpFixture()
        {
            this.Secret = "12345678901234567890";
        }

        public string Secret { get; set; }
    }
}
