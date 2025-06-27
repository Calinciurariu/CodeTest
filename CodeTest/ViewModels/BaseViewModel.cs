using CodeTest.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeTest.ViewModels
{
    public partial class BaseTestViewModel : ObservableObject, IViewModel
    {
        protected INavigationPageService Navigation;

        public bool IsConnected => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        public virtual async Task BackHandler()
        {
            await Navigation.PopAsync();
        }
        [RelayCommand(AllowConcurrentExecutions = false)]
        private async Task GoBack()
        {
            await BackHandler();
        }
        public BaseTestViewModel(INavigationPageService navigation)
        {
            Navigation = navigation;
        }
        [ObservableProperty]
        bool isBusy = false;
        [ObservableProperty]
        bool isRefreshing = false;
        public virtual void SetParameters(IDictionary<string, object> parameters) { }
       
    }
}
