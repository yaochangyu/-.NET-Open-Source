@echo off
NuGet SetApiKey 15161532-AB33-4EB8-8CA3-F9ECDDD25FAF -Source http://nttp3ts15/NuGetServer

Nuget Sources Add -Name Tako.Serialization -UserName nttp3\§E¤p³¹ -Password Pass@2014W0rd2~
NuGet Pack Tako.Serialization.1.0.0.0.nuspec -Version 1.0.0.0
NuGet Push Tako.Serialization.1.0.0.0.nupkg -Source http://nttp3ts15/NuGetServer -UserName nttp3\§E¤p³¹ -Password Pass@2014W0rd2~
pause
Exit 0
