build :
	devenv wouldyou.sln /build Release

debug :
	devenv wouldyou.sln /build Debug

clean :
	devenv wouldyou.sln /clean

install :
	copy bin\release\wouldyou.exe "%USERPROFILE%\bin\."
