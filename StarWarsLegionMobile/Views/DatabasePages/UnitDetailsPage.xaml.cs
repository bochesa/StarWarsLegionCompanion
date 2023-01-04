using StarWarsLegionMobile.ViewModels;

namespace StarWarsLegionMobile.Views;

public partial class UnitDetailsPage : ContentPage
{
	public UnitDetailsPage(UnitDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;	
	}
}