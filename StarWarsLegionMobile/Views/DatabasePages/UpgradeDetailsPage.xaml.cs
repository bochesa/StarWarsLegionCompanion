namespace StarWarsLegionMobile.Views;

public partial class UpgradeDetailsPage : ContentPage
{
	public UpgradeDetailsPage(UpgradeDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}