namespace Albireo.Otp.Library
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    internal static class Base32
    {
        private static readonly char[] Alphabet =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z', '2', '3', '4', '5', '6', '7'
        };

        internal static string Encode(byte[] input)
        {
            Contract.Requires<ArgumentException>(input != null);
            Contract.Ensures(Contract.Result<string>() != null);
            if (input.Length == 0) return string.Empty;
            var bits = input.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).Aggregate((x, y) => x + y);
            if (bits.Length % 5 != 0) bits += string.Concat(Enumerable.Repeat('0', 5 - bits.Length % 5));
            var output = new StringBuilder(bits.Length / 5);
            for (int i = 0, j = bits.Length / 5; i < j; i++) output.Append(Alphabet[Convert.ToInt32(bits.Substring(5 * i, 5), 2)]);
            while (output.Length % 8 != 0) output.Append('=');
            return output.ToString();
        }

        internal static byte[] Decode(string input)
        {
            Contract.Requires<ArgumentNullException>(input != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            if (string.IsNullOrEmpty(input)) return new byte[0];
            input = input.TrimEnd('=');
            var bits = input.Select(x => Convert.ToString(Array.IndexOf(Alphabet, x), 2).PadLeft(5, '0')).Aggregate((x , y) => x + y);
            var output = new byte[bits.Length / 8];
            for (int i = 0, j = bits.Length / 8; i < j; i++) output[i] = Convert.ToByte(bits.Substring(8 * i, 8), 2);
            return output;
        }
    }
}
