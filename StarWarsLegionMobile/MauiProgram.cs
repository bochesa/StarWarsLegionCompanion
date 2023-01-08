using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using StarWarsLegionMobile.Services;
using StarWarsLegionMobile.Views;

namespace StarWarsLegionMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontRegular");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FontBrands");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontSolid");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            // services
            builder.Services.AddSingleton<DatabaseServices>();

            // Viewmodels
            // list pages
            builder.Services.AddSingleton<KeywordViewModel>();
            builder.Services.AddSingleton<UpgradeViewModel>();
            builder.Services.AddSingleton<UnitViewModel>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ArmyViewModel>();
            builder.Services.AddSingleton<ArmyListViewModel>();

            // viewmodels for detail pages
            builder.Services.AddTransient<KeywordDetailsViewModel>();
            builder.Services.AddTransient<UpgradeDetailsViewModel>();
            builder.Services.AddTransient<UnitDetailsViewModel>();
            builder.Services.AddTransient<TestViewModel>();
            builder.Services.AddTransient<PickUnitViewModel>();
            
            //pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<KeywordsPage>();
            builder.Services.AddSingleton<UpgradesPage>();
            builder.Services.AddSingleton<UnitsPage>();
            builder.Services.AddSingleton<ArmyListPage>();

            builder.Services.AddTransient<KeywordDetailsPage>();
            builder.Services.AddTransient<UpgradeDetailsPage>();
            builder.Services.AddTransient<UnitDetailsPage>();
            builder.Services.AddTransient<ArmyBuilderPage>();
            builder.Services.AddTransient<TestPage>();
            builder.Services.AddTransient<PickUnitPage>();

            return builder.Build();
        }
    }
}