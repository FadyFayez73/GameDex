using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using System.Diagnostics;

namespace GameDexApp;

public static class ApiStarter
{
    private static Process? _apiProcess;

    public static void StartApi()
    {
        var backendFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "API");
        var apiExe = Path.Combine(backendFolder, "API.exe");

        var startInfo = new ProcessStartInfo
        {
            FileName = apiExe,
            WorkingDirectory = backendFolder,
            CreateNoWindow = true,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        _apiProcess = Process.Start(startInfo);
    }

    public static async Task<bool> IsApiReady()
    {
        var client = new HttpClient();
        try
        {
            var response = await client.GetAsync("http://localhost:5000/Games");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public static void StopApi()
    {
        if (_apiProcess != null && !_apiProcess.HasExited)
        {
            _apiProcess.Kill();
            _apiProcess.Dispose();
        }
    }
}
