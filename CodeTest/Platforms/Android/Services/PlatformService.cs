using CodeTest.Interfaces;

namespace CodeTest.Platforms.Android.Services
{
    public partial class PlatformService : IPlatformService
    {
        public string GetPlatformName()
        {
            return "Android";
        }
    }
}
