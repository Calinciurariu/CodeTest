using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Interfaces
{
    public interface INavigationPageService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>(string route, IDictionary<string, object> routeParameters = null)
            where TViewModel : class, IViewModel;
        Task PopAndNavigateToAsync<TViewModel>(string route, IDictionary<string, object> routeParameters = null)
            where TViewModel : class, IViewModel;

        Task PopAsync();

        Task PopToRootAsync();

        void ClearStackAndGoToRoot();

        Task<object> ShowPopupAsync(object page);

        Task<bool> RedirectToReferrer();
    }
}
