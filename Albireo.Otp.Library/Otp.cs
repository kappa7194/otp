namespace Albireo.Otp.Library
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal static class Otp
    {
        internal const int DefaultDigits = 6;

        internal static int GetCode(string secret, long counter, int digits)
        {
            Contract.Requires<ArgumentNullException>(secret != null);
            Contract.Requires<ArgumentOutOfRangeException>(counter >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(digits > 0);
            Contract.Ensures(Contract.Result<int>() > 0);
            Contract.Ensures(Contract.Result<int>() < Math.Pow(10, digits));
            secret = Base32.Encode(Encoding.UTF8.GetBytes(secret));
            var generator = new HMACSHA1(Base32.Decode(secret));
            generator.ComputeHash(CounterToBytes(counter));
            var hmac = generator.Hash.Select(b => int.Parse(b.ToString("x2"), NumberStyles.HexNumber)).ToArray();
            var offset = hmac[19] & 0xF;
            var code = (hmac[offset + 0] & 0x7F) << 24 | (hmac[offset + 1] & 0xFF) << 16 | (hmac[offset + 2] & 0xFF) << 8 | (hmac[offset + 3] & 0xFF);
            return code % (int) Math.Pow(10, digits);
        }

        private static byte[] CounterToBytes(long counter)
        {
            Contract.Requires<ArgumentOutOfRangeException>(counter >= 0);
            Contract.Ensures(Contract.Result<byte[]>() != null);
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
