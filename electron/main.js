const { app, BrowserWindow } = require('electron');
const path = require('path');
const { spawn } = require('child_process');
const waitOn = require('wait-on');

let apiProcess;
let win;

const isDev = true;

function startApi() {
  const dllPath =
    path.join(__dirname, '..', 'GameDex.APIServer', 'bin', 'Debug', 'net6.0', 'GameDex.APIServer.dll');

  console.log('🔧 Starting API at:', dllPath); // أضف هنا

  apiProcess = spawn('dotnet', [dllPath], {
    detached: true,
    stdio: 'inherit',
  });

  apiProcess.unref();

  console.log('✅ API process spawned'); // أضف هنا
}

function createWindow() {
  win = new BrowserWindow({
    width: 1250,
    height: 800,
    webPreferences: {
      contextIsolation: true,
      preload: path.join(__dirname, 'preload.js'),
    },
  });

  if (isDev) {
    win.loadURL('http://localhost:3000');
  } else {
    const indexPath = path.join(__dirname, '..', 'react-app', 'out', 'index.html');
    win.loadFile(indexPath);
  }

  win.on('closed', () => {
    if (apiProcess) process.kill(-apiProcess.pid);
  });
}

app.whenReady().then(() => {
  startApi();
  waitOn({ resources: ['http://localhost:5000'] }, createWindow);
});

app.on('window-all-closed', () => {
  if (apiProcess) process.kill(-apiProcess.pid);
  app.quit();
});
