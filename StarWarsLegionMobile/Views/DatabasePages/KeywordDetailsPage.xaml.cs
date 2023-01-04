namespace StarWarsLegionMobile.Views;

public partial class KeywordDetailsPage : ContentPage
{
	public KeywordDetailsPage(KeywordDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}