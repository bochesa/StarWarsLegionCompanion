namespace StarWarsLegionMobile.Views;

public partial class ArmyBuilderPage : ContentPage
{
    ArmyViewModel viewModel;

    public ArmyBuilderPage(ArmyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
        this.viewModel= viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.Title = viewModel.Army.Name;
    }
}