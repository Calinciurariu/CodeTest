using CodeTest.ViewModels;

namespace CodeTest
{
    public partial class App : Application
    {
        public App(MainPage vm)
        {
            InitializeComponent();

            MainPage = new NavigationPage(vm);
        }
    }
}
