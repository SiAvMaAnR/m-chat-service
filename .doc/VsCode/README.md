### VsCode: launch.json

```
{
    "version": "0.2.0",
    "configurations": [
      {
        "name": ".NET Core Launch (Development)",
        "type": "coreclr",
        "request": "launch",
        "preLaunchTask": "build",
        "program": "${workspaceFolder}/Chat.WebApi/bin/Debug/net8.0/Chat.WebApi.dll",
        "args": [],
        "cwd": "${workspaceFolder}/Chat.WebApi",
        "stopAtEntry": false,
        "console": "integratedTerminal",
        "requireExactSource": false,
        "serverReadyAction": {
          "uriFormat": "%s/swagger"
        },
        "launchSettingsProfile": "Chat.Development"
      },
      {
        "name": ".NET Core Launch (Production)",
        "type": "coreclr",
        "request": "launch",
        "preLaunchTask": "build",
        "program": "${workspaceFolder}/Chat.WebApi/bin/Debug/net8.0/Chat.WebApi.dll",
        "args": [],
        "cwd": "${workspaceFolder}/Chat.WebApi",
        "stopAtEntry": false,
        "console": "integratedTerminal",
        "launchSettingsProfile": "Chat.Production"
      }
    ]
}
```

### VsCode: settings.json

Exclude bin, obj folders:
F1 > Open workspace settings > Text editor > Files > Exclude

```
{
  "files.exclude": {
    "**/bin": true,
    "**/obj": true
  }
}
```
