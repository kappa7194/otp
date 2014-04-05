namespace Albireo.Otp.Tests
{
    using Xunit;

    public class HotpTests : IUseFixture<HotpFixture>
    {
        private string secret;

        public void SetFixture(HotpFixture data)
        {
            this.secret = data.Secret;
        }

        public class GetCodeTests : HotpTests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(755224, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 0));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(287082, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 1));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(359152, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 2));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(969429, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 3));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(338314, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 4));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(254676, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 5));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal(287922, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 6));
            }

            [Fact]
            public void Vector8()
            {
                Assert.Equal(162583, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 7));
            }

            [Fact]
            public void Vector9()
            {
                Assert.Equal(399871, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 8));
            }

            [Fact]
            public void Vector10()
            {
                Assert.Equal(520489, Hotp.GetCode(HashAlgorithm.Sha1, this.secret, 9));
            }
        }
    }
}
