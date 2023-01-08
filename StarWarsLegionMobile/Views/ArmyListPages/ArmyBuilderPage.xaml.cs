namespace StarWarsLegionMobile.Views;

public partial class ArmyBuilderPage : ContentPage
{
    ArmyViewModel viewModel;

    public ArmyBuilderPage(ArmyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
    }

}