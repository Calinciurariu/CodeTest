using CodeTest.Interfaces;

namespace CodeTest.Platforms.iOS.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlatformName()
        {
            return "iOS";
        }
    }
}
