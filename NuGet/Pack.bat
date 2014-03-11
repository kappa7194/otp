@ECHO OFF
NuGet.exe Update -Self
NuGet.exe Pack ..\Albireo.Otp\Albireo.Otp.csproj -Prop Configuration=Release -Symbols
