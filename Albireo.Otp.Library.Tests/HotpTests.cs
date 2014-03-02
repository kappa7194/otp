namespace Albireo.Otp.Library.Tests
{
    using Xunit;

    public class HotpTests : IUseFixture<HotpFixture>
    {
        private Hotp hotp;

        public void SetFixture(HotpFixture data)
        {
            this.hotp = data.Hotp;
        }

        public class GetCodeTests : HotpTests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(755224, this.hotp.GetCode(0));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(287082, this.hotp.GetCode(1));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(359152, this.hotp.GetCode(2));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(969429, this.hotp.GetCode(3));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(338314, this.hotp.GetCode(4));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(254676, this.hotp.GetCode(5));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal(287922, this.hotp.GetCode(6));
            }

            [Fact]
            public void Vector8()
            {
                Assert.Equal(162583, this.hotp.GetCode(7));
            }

            [Fact]
            public void Vector9()
            {
                Assert.Equal(399871, this.hotp.GetCode(8));
            }

            [Fact]
            public void Vector10()
            {
                Assert.Equal(520489, this.hotp.GetCode(9));
            }
        }
    }
}
