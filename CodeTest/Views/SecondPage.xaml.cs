using CodeTest.ViewModels;


namespace CodeTest
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage(SecondPageViewModel secondPageViewModel)
        {
            InitializeComponent();
            BindingContext = secondPageViewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await welcomeLabel.FadeTo(1, 1000); // Fade in over 1 second
        }
    }
}