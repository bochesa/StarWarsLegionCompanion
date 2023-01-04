using StarWarsLegionMobile.Views;

namespace StarWarsLegionMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(KeywordDetailsPage), typeof(KeywordDetailsPage));
        Routing.RegisterRoute(nameof(UpgradeDetailsPage), typeof(UpgradeDetailsPage));
        Routing.RegisterRoute(nameof(UnitDetailsPage), typeof(UnitDetailsPage));
        Routing.RegisterRoute(nameof(ArmyBuilderPage), typeof(ArmyBuilderPage));
        Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));

    }
}
