const { app, BrowserWindow } = require('electron');
const { exec } = require('child_process');

function createWindow () {
  const win = new BrowserWindow({
    width: 1000,
    height: 700,
    webPreferences: {
      nodeIntegration: true
    }
  });

  win.loadURL('https://localhost:7165'); // أو UI خاص بيك لو عندك
}

// شغل الـ API أولًا
app.whenReady().then(() => {
  exec('dotnet ../API/bin/Debug/net9.0/API.dll', (error, stdout, stderr) => {
    if (error) {
      console.error(`Error starting API: ${error.message}`);
      return;
    }
    console.log('API Started');
    createWindow();
  });
});

app.on('window-all-closed', () => {
  app.quit();
});
