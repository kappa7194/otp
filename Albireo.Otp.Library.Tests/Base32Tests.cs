namespace Albireo.Otp.Library.Tests
{
    using System.Text;
    using Xunit;

    public class Base32Tests
    {
        public class ToStringTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(string.Empty, Base32.ToString(StringToBytes(string.Empty)));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal("MY======", Base32.ToString(StringToBytes("f")));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal("MZXQ====", Base32.ToString(StringToBytes("fo")));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal("MZXW6===", Base32.ToString(StringToBytes("foo")));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal("MZXW6YQ=", Base32.ToString(StringToBytes("foob")));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal("MZXW6YTB", Base32.ToString(StringToBytes("fooba")));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal("MZXW6YTBOI======", Base32.ToString(StringToBytes("foobar")));
            }
        }
        public class ToBytesTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(StringToBytes(string.Empty), Base32.ToBytes(string.Empty));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(StringToBytes("f"), Base32.ToBytes("MY======"));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(StringToBytes("fo"), Base32.ToBytes("MZXQ===="));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(StringToBytes("foo"), Base32.ToBytes("MZXW6==="));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(StringToBytes("foob"), Base32.ToBytes("MZXW6YQ="));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(StringToBytes("fooba"), Base32.ToBytes("MZXW6YTB"));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal(StringToBytes("foobar"), Base32.ToBytes("MZXW6YTBOI======"));
            }
        }

        private byte[] StringToBytes(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }
    }
}
