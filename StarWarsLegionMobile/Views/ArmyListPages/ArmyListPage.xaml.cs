namespace StarWarsLegionMobile.Views;

public partial class ArmyListPage : ContentPage
{
    ArmyListViewModel viewModel;

    public ArmyListPage(ArmyListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
		this.viewModel= viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetArmiesCommand.Execute(this);
    }
}