namespace GameDexApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var fullPath = Path.Combine(AppContext.BaseDirectory, "Content", "index.html");

            var webView = new WebView
            {
                Source = fullPath,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = webView;
        }
    }
}