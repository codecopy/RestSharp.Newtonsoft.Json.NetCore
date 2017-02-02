@ECHO OFF
dotnet restore
dotnet test test\RestSharp.Newtonsoft.Json.NetCore.Tests -appveyor
dotnet pack src\RestSharp.Newtonsoft.Json.NetCore --configuration Release