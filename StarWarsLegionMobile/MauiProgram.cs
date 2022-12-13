using Microsoft.Extensions.Logging;

namespace StarWarsLegionMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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

            return builder.Build();
        }
    }
}