namespace StarWarsLegionMobile.Views;

public partial class UpgradesPage : ContentPage
{

    UpgradeViewModel viewModel;
    public UpgradesPage(UpgradeViewModel viewModel)
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