namespace GameDexApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                ApiStarter.StopApi();
            };
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            ApiStarter.StartApi(); // Start the API when the app starts
            var window = new Window(new AppShell());

            Task.Run(async () => 
            {
                var status =  await ApiStarter.IsApiReady();
                if(!status) Current?.Quit();
            });

            return window;
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            ApiStarter.StopApi(); // Stop the API when the app goes to sleep
        }
    }
}