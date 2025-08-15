namespace Example.ProjectName.Designer.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnToggleButtonClicked(object sender, EventArgs e)
        {
            if (this.ToggleBtn.IsToggled == true)
            {
                count++;
                this.ToggleBtn.Content = $"Toggled {count} times";
            }
            else
            {
                this.ToggleBtn.Content = "Click to toggle";
            }
        }
    }
}
