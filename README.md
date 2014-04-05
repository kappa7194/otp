# One-Time Password

This .NET library allows two factor authentication using either HOTP or TOTP.

A NuGet package is available at https://www.nuget.org/packages/Albireo.Otp/

## License

This project is licensed under [the MIT license], you can find a copy of the license in the LICENSE.txt file.

## Requirments

- Microsoft Visual Studio 2013
- Code Contracts

## Credits

The `Otp` class has been adapted from [Nathan Adams]' [OTPNet] project and it has been re-licensed under the MIT license with permission from the author. Its full copyright chain is listed below.

 - Copyright © 2011 Mark Percival https://github.com/mdp/rotp
 - Copyright © 2011 Le Lag https://github.com/lelag/otphp
 - Copyright © 2012 Nathan Adams https://github.com/nadams810/otpnet
 - Copyright © 2014 Albireo https://github.com/kappa7194/otp

The tests vectors for the HOTP implementations are taken from [RFC 4226]'s [Appendix D].

The tests vectors for the TOTP implementations are taken from [RFC 6238]'s [Appendix B].

  [the MIT license]: https://opensource.org/licenses/MIT
  [Nathan Adams]: https://srchub.org/u/nadams/
  [OTPNet]: https://github.com/nadams810/otpnet
  [RFC 4226]: https://tools.ietf.org/html/rfc4226
  [Appendix D]: https://tools.ietf.org/html/rfc4226#appendix-D
  [RFC 6238]: https://tools.ietf.org/html/rfc6238
  [Appendix B]: https://tools.ietf.org/html/rfc6238#appendix-B
