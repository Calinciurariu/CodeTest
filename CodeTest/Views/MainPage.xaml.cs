using CodeTest.ViewModels;

namespace CodeTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await image.FadeTo(1, 1000); // Fade in over 1 second
        }
    }

}
