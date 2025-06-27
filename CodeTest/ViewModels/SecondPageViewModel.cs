using CodeTest.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.ViewModels
{
    public partial class SecondPageViewModel : BaseTestViewModel
    {
        #region Services
        private readonly IPlatformService platformService;
        #endregion

        #region Properties
        private string userName="undefined username";
        private string platformName = "undefined platform";

        [ObservableProperty]
        string welcomeText= "undefined welcome text";
        #endregion

        public SecondPageViewModel(INavigationPageService navigation, IPlatformService platformService) : base(navigation)
        {
          this.platformService = platformService;
        }
        public override void SetParameters(IDictionary<string, object> routeParameters)
        {
            base.SetParameters(routeParameters); 

            userName = routeParameters["UserName"] as string;
        }

        #region Commands

        [RelayCommand(AllowConcurrentExecutions = false)]

        private async Task Appearing()
        {
            IsBusy = true;

            try
            {
                platformName = platformService.GetPlatformName();
                await Task.Delay(200);
                WelcomeText = $"Welcome {userName} from {platformName}";

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error on Platform Service: " + ex.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
