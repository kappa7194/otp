namespace Albireo.Otp.Tests
{
    public class TotpFixture
    {
        public TotpFixture()
        {
            this.Secret = "12345678901234567890";
            this.Digits = 8;
        }

        public string Secret { get; set; }
        public int Digits { get; set; }
    }
}
