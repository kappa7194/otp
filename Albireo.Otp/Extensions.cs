namespace Albireo.Otp
{
    using System;
    using System.Diagnostics.Contracts;

    internal static class Extensions
    {
        internal static string ToKeyUriValue(this OtpType type)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(OtpType), type));
            Contract.Requires<ArgumentOutOfRangeException>(type != OtpType.Unknown);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

            switch (type)
            {
                case OtpType.Totp:
                    return "totp";

                case OtpType.Hotp:
                    return "hotp";

                default:
                    throw new NotSupportedException();
            }
        }

        internal static string ToKeyUriValue(this HashAlgorithm algorithm)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(HashAlgorithm), algorithm));
            Contract.Requires<ArgumentOutOfRangeException>(algorithm != HashAlgorithm.Unknown);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

            switch (algorithm)
            {
                case HashAlgorithm.Md5:
                    return "MD5";

                case HashAlgorithm.Sha1:
                    return "SHA1";

                case HashAlgorithm.Sha256:
                    return "SHA256";

                case HashAlgorithm.Sha512:
                    return "SHA512";

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
