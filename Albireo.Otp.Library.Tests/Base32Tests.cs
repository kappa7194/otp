namespace Albireo.Otp.Library.Tests
{
    using System.Text;
    using Xunit;

    public class Base32Tests
    {
        public class EncodeTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(string.Empty, Base32.Encode(StringToBytes(string.Empty)));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal("MY======", Base32.Encode(StringToBytes("f")));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal("MZXQ====", Base32.Encode(StringToBytes("fo")));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal("MZXW6===", Base32.Encode(StringToBytes("foo")));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal("MZXW6YQ=", Base32.Encode(StringToBytes("foob")));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal("MZXW6YTB", Base32.Encode(StringToBytes("fooba")));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal("MZXW6YTBOI======", Base32.Encode(StringToBytes("foobar")));
            }
        }
        public class DecodeTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(StringToBytes(string.Empty), Base32.Decode(string.Empty));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(StringToBytes("f"), Base32.Decode("MY======"));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(StringToBytes("fo"), Base32.Decode("MZXQ===="));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(StringToBytes("foo"), Base32.Decode("MZXW6==="));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(StringToBytes("foob"), Base32.Decode("MZXW6YQ="));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(StringToBytes("fooba"), Base32.Decode("MZXW6YTB"));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal(StringToBytes("foobar"), Base32.Decode("MZXW6YTBOI======"));
            }
        }

        private byte[] StringToBytes(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }
    }
}
