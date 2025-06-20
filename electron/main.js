const { app, BrowserWindow } = require('electron');
const path = require('path');
const { spawn } = require('child_process');

let apiProcess;
let win;

const isDev = true; // لو حبيت تغير لاحقًا

function createWindow() {
  win = new BrowserWindow({
    width: 1200,
    height: 800,
    webPreferences: {
      contextIsolation: true,
    },
  });

  if (isDev) {
    // ✅ افتح React dev server
    win.loadURL('http://localhost:3000');

    // ✅ شغّل Web API
    const apiDllPath = path.join(__dirname, '..', 'GameDex.WebAPI', 'bin', 'Debug', 'net6.0', 'GameDex.WebAPI.dll');
    apiProcess = spawn('dotnet', [apiDllPath], {
      detached: true,
      stdio: 'ignore',
    });
  } else {
    // ✅ افتح React من build
    const indexPath = path.join(__dirname, '..', 'react-app', 'build', 'index.html');
    win.loadFile(indexPath);

    // ✅ شغّل Web API من مجلد publish
    const apiDllPath = path.join(__dirname, 'webapi', 'GameDex.WebAPI.dll');
    apiProcess = spawn('dotnet', [apiDllPath], {
      detached: true,
      stdio: 'ignore',
    });
  }

  win.on('closed', () => {
    if (apiProcess) process.kill(-apiProcess.pid);
  });
}

app.whenReady().then(createWindow);

app.on('window-all-closed', () => {
  if (apiProcess) process.kill(-apiProcess.pid);
  app.quit();
});
