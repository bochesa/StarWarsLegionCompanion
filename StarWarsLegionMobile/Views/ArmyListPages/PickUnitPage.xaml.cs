namespace StarWarsLegionMobile.Views;

public partial class PickUnitPage : ContentPage
{
    PickUnitViewModel viewModel;

    public PickUnitPage(PickUnitViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
        this.viewModel= viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetUnitsCommand.Execute(this);
    }
}