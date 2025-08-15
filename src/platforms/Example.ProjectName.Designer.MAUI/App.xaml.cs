namespace Example.ProjectName.Designer.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            TelerikThemeResources.AppTheme = TelerikTheme.TelerikTurquoiseDark;

            if (TelerikThemeResources.AppTheme.ToString().EndsWith("Dark"))
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
