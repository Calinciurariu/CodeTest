using CodeTest.Controls;
using CodeTest.Helpers;
using CodeTest.Interfaces;
#if IOS
using CodeTest.Platforms.iOS.Services;
#elif ANDROID
using CodeTest.Platforms.Android.Handlers;
using CodeTest.Platforms.Android.Services;
#endif
using CodeTest.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace CodeTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility()
                .UseMauiCommunityToolkit()
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                handlers.AddHandler(typeof(ScrollingLabelInternal), typeof(ScrollingLabelInternalViewHandler));
                handlers.AddHandler(typeof(ScrollingLabel), typeof(ScrollingLabelHandler));
#endif
                }
                )
                .UseCustomNavigation()
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews()
                .MapViewMoldelsToPages()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FontAwesome6Brands.otf", "FontAwesomeBrands");
                    fonts.AddFont("FontAwesome6Duotone.otf", "FontAwesomeDuotone");
                    fonts.AddFont("FontAwesome6Light.otf", "FontAwesomeLight");
                    fonts.AddFont("FontAwesome6Regular.otf", "FontAwesomeRegular");
                    fonts.AddFont("FontAwesome6Solid.otf", "FontAwesomeSolid");
                    fonts.AddFont("FontAwesome6Thin.otf", "FontAwesomeThin");


                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

   
        public static MauiAppBuilder MapViewMoldelsToPages(this MauiAppBuilder mauiAppBuilder)
        {
            Initializer.RegisterViewModelToPage<MainPage, MainPageViewModel>();
            Initializer.RegisterViewModelToPage<SecondPage, SecondPageViewModel>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IPlatformService, PlatformService>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
            mauiAppBuilder.Services.AddTransient<SecondPageViewModel>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<SecondPage>();
            return mauiAppBuilder;
        }
    }
}
