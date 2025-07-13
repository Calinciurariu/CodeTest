using CodeTest.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeTest.ViewModels
{
    public partial class MainPageViewModel : BaseTestViewModel
    {
        #region properties
        [ObservableProperty]
        string welcomeText;
        string username; 
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        #endregion
        public MainPageViewModel(INavigationPageService navigation) : base(navigation)
        {
            
        }
        #region Commands

        [RelayCommand(AllowConcurrentExecutions =false)]
        private async Task NavigateToSecondPage()
        {
     

            if (string.IsNullOrWhiteSpace(Username))
                return;
            WelcomeText += Username;
        }

        [RelayCommand(AllowConcurrentExecutions = false)]

        private async Task Appearing()
        {
            IsBusy = true;
            Task.Delay(450);
            IsBusy = false;
        }
        #endregion
    }
}
