namespace StarWarsLegionMobile.Views;

public partial class ArmyBuilderPage : ContentPage
{
	public ArmyBuilderPage(ArmyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}