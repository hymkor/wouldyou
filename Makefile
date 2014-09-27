build :
	devenv wouldyou.sln /build Release

debug :
	devenv wouldyou.sln /build Debug

clean :
	devenv wouldyou.sln /clean

snapshot :
	zip -9j wouldyou-%DATE:/=%.zip bin\Release\wouldyou.exe readme.md

install :
	copy bin\release\wouldyou.exe "%USERPROFILE%\bin\."
