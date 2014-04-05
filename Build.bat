PUSHD otp
git reset --hard
git clean -d -f -x
NuGet.exe Restore Albireo.Otp.sln
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Albireo.Otp.sln /property:Configuration=Debug /maxcpucount /nodeReuse:false
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Albireo.Otp.sln /property:Configuration=Release /maxcpucount /nodeReuse:false
NuGet.exe Pack Albireo.Otp\Albireo.Otp.csproj -Prop Configuration=Release -Symbols
POPD
PAUSE
