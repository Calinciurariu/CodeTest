using CodeTest.Helpers;
using CodeTest.Interfaces;

namespace CodeTest.Services
{
    public class NavigationPageService : INavigationPageService
    {
        public void ClearStackAndGoToRoot()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopAsync()
        {
            return Application.Current.MainPage.Navigation.PopAsync(true);
        }

        public Task PopToRootAsync()
        {
            return Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        public Task<bool> RedirectToReferrer()
        {
            throw new NotImplementedException();
        }

        public Task<object> ShowPopupAsync(object page)
        {
            throw new NotImplementedException();
        }

        Task INavigationPageService.NavigateToAsync<TViewModel>(string route, IDictionary<string, object> routeParameters)
        {
            var pageType = Initializer.GetPageTypeFromVM<TViewModel>();
            var currentPage = Application.Current.MainPage;
            var page = currentPage.Handler.MauiContext.Services.GetService(pageType) as Page;
            if (routeParameters != null && routeParameters.Count > 0)
                (page.BindingContext as IViewModel).SetParameters(routeParameters);

            return currentPage.Navigation.PushAsync(page);
        }

        Task INavigationPageService.PopAndNavigateToAsync<TViewModel>(string route, IDictionary<string, object> routeParameters)
        {
            throw new NotImplementedException();
        }
    }
}
