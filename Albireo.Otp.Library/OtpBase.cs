namespace Albireo.Otp.Library
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;

    public abstract class OtpBase
    {
        public const int DefaultDigits = 6;

        private readonly string secret;
        private readonly int digits;

        protected OtpBase(string secret, int digits = DefaultDigits)
        {
            this.secret = secret;
            this.digits = digits;
        }

        protected int Generate(long counter)
        {
            var generator = new HMACSHA1(Base32.ToBytes(this.secret));
            generator.ComputeHash(CounterToBytes(counter));
            var hmac = generator.Hash.Select(b => int.Parse(b.ToString("x2"), NumberStyles.HexNumber)).ToArray();
            var offset = hmac[19] & 0xF;
            var code = (hmac[offset + 0] & 0x7F) << 24 | (hmac[offset + 1] & 0xFF) << 16 | (hmac[offset + 2] & 0xFF) << 8 | (hmac[offset + 3] & 0xFF);
            return code % (int) Math.Pow(10, this.digits);
        }

        private static byte[] CounterToBytes(long counter)
        {
            var result = new List<byte>();
            while (counter != 0)
            {
                result.Add((byte) (counter & 0xFF));
                counter >>= 8;
            }
            for (int i = 0, j = 8 - result.Count; i < j; i++) result.Add(0);
            result.Reverse();
            return result.ToArray();
        }
    }
}
