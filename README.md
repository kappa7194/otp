# C# One-Time Password

TODO

## License

This project is licensed under [the MIT license], you can find a copy of the license in the LICENSE.txt file.

### Base32 class

The `Base32` class has been adapted from [Shane's answer] to the [Base32 Decoding] StackOverflow question and is licensed under the [Creative Commons BY-SA 3.0] license.

## Credits

The `Otp` class has been adapted from [Nathan Adams]' [OTPNet] project and it has been re-licensed under the MIT license with permission from the author. Its full copyright chain is listed below.

 - Copyright © 2011 Mark Percival https://github.com/mdp/rotp
 - Copyright © 2011 Le Lag https://github.com/lelag/otphp
 - Copyright © 2012 Nathan Adams https://github.com/nadams810/otpnet
 - Copyright © 2014 Albireo https://github.com/kappa7194/otp

The tests vectors for the HOTP implementations are taken from [RFC 4226]'s [Appendix D].

The tests vectors for the TOTP implementations are taken from [RFC 6238]'s [Appendix B].

  [the MIT license]: https://opensource.org/licenses/MIT
  [Shane's answer]: https://stackoverflow.com/a/7135008
  [Base32 Decoding]: https://stackoverflow.com/q/641361
  [Creative Commons BY-SA 3.0]: https://creativecommons.org/licenses/by-sa/3.0/
  [Nathan Adams]: https://srchub.org/u/nadams/
  [OTPNet]: https://github.com/nadams810/otpnet
  [RFC 4226]: https://tools.ietf.org/html/rfc4226
  [Appendix D]: https://tools.ietf.org/html/rfc4226#appendix-D
  [RFC 6238]: https://tools.ietf.org/html/rfc6238
  [Appendix B]: https://tools.ietf.org/html/rfc6238#appendix-B
