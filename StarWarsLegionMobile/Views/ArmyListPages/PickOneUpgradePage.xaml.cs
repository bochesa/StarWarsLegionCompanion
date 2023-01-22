namespace StarWarsLegionMobile.Views;

public partial class PickOneUpgradePage : ContentPage
{
    PickOneUpgradeViewModel viewModel;

    public PickOneUpgradePage(PickOneUpgradeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetUpgradesCommand.Execute(this);
    }
}