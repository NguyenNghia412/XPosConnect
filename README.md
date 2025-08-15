**Publish project**

`dotnet publish -c Release -r win-x86 --self-contained false`

**Cài service**

```
sc create XPosConnectService binPath= "E:\Code\XPosConnect\XPosConnect\bin\Release\net8.0\win-x86\XPosConnect.exe" start= auto
sc start XPosConnectService
sc delete XPosConnectService
```
