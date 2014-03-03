namespace Albireo.Otp.Library
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;

    internal static class Base32
    {
        internal static byte[] ToBytes(string input)
        {
            Contract.Requires<ArgumentNullException>(input != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            if (input.Length == 0) return new byte[0];
            input = input.TrimEnd('=');
            var byteCount = input.Length * 5 / 8;
            var result = new byte[byteCount];
            byte currentByte = 0, bitsRemaining = 8;
            var arrayIndex = 0;
            foreach (var value in input.Select(CharToValue))
            {
                int mask;
                if (bitsRemaining > 5)
                {
                    mask = value << (bitsRemaining - 5);
                    currentByte = (byte) (currentByte | mask);
                    bitsRemaining -= 5;
                }
                else
                {
                    mask = value >> (5 - bitsRemaining);
                    currentByte = (byte) (currentByte | mask);
                    result[arrayIndex++] = currentByte;
                    unchecked
                    {
                        currentByte = (byte) (value << (3 + bitsRemaining));
                    }
                    bitsRemaining += 3;
                }
            }
            if (arrayIndex != byteCount) result[arrayIndex] = currentByte;
            return result;
        }

        internal static string ToString(byte[] input)
        {
            Contract.Requires<ArgumentNullException>(input != null);
            Contract.Ensures(Contract.Result<string>() != null);
            if (input.Length == 0) return string.Empty;
            var charCount = (int) Math.Ceiling(input.Length / 5d) * 8;
            var result = new char[charCount];
            byte nextChar = 0, bitsRemaining = 5;
            var arrayIndex = 0;
            foreach (var b in input)
            {
                nextChar = (byte) (nextChar | (b >> (8 - bitsRemaining)));
                result[arrayIndex++] = ValueToChar(nextChar);
                if (bitsRemaining < 4)
                {
                    nextChar = (byte) ((b >> (3 - bitsRemaining)) & 31);
                    result[arrayIndex++] = ValueToChar(nextChar);
                    bitsRemaining += 5;
                }
                bitsRemaining -= 3;
                nextChar = (byte) ((b << bitsRemaining) & 31);
            }
            if (arrayIndex == charCount) return new string(result);
            result[arrayIndex++] = ValueToChar(nextChar);
            while (arrayIndex != charCount) result[arrayIndex++] = '=';
            return new string(result);
        }

        private static int CharToValue(char c)
        {
            var value = (int) c;
            if (value < 91 && value > 64) return value - 65;
            if (value < 56 && value > 49) return value - 24;
            if (value < 123 && value > 96) return value - 97;
            throw new ArgumentException("Character is not a Base32 character.", "c");
        }

        private static char ValueToChar(byte b)
        {
            if (b < 26) return (char) (b + 65);
            if (b < 32) return (char) (b + 24);
            throw new ArgumentException("Byte is not a value Base32 value.", "b");
        }

    }
}
