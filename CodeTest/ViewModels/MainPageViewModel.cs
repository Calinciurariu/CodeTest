using CodeTest.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeTest.ViewModels
{
    public partial class MainPageViewModel : BaseTestViewModel
    {
        #region properties
        [ObservableProperty]
        string username; 
        #endregion
        public MainPageViewModel(INavigationPageService navigation) : base(navigation)
        {
            
        }
        #region Commands

        [RelayCommand(AllowConcurrentExecutions =false)]
        private async Task NavigateToSecondPage()
        {
            IsBusy = true;
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                await Application.Current.MainPage.DisplayAlert("Error", "You can't just leave the username empty " , "OK");
                    return;
                }
                var paramsToPass = new Dictionary<string, object> { };
                paramsToPass.Add("UserName", username);
                await Navigation.NavigateToAsync<SecondPageViewModel>(nameof(SecondPageViewModel), paramsToPass);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "An error occurred while navigating: " + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

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
