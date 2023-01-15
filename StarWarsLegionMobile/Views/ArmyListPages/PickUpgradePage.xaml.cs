namespace StarWarsLegionMobile.Views;

public partial class PickUpgradePage : ContentPage
{
    PickUpgradeViewModel viewModel;

    public PickUpgradePage(PickUpgradeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
        this.viewModel= viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetUpgradesCommand.Execute(this);
    }
}