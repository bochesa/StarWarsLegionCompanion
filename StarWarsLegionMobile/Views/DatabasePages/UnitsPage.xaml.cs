namespace StarWarsLegionMobile.Views;

public partial class UnitsPage : ContentPage
{

    UnitViewModel viewModel;
    public UnitsPage(UnitViewModel viewModel)
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