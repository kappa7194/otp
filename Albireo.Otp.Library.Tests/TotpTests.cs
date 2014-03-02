namespace Albireo.Otp.Library.Tests
{
    using System;
    using Xunit;

    public class TotpTests : IUseFixture<TotpFixture>
    {
        private Totp totp;

        public void SetFixture(TotpFixture data)
        {
            this.totp = data.Totp;
        }

        public class GetCodeTests : TotpTests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(94287082, this.totp.GetCode(new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc)));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(07081804, this.totp.GetCode(new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc)));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(14050471, this.totp.GetCode(new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc)));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(89005924, this.totp.GetCode(new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc)));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(69279037, this.totp.GetCode(new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc)));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(65353130, this.totp.GetCode(new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc)));
            }
        }
    }
}
