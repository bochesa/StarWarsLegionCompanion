namespace StarWarsLegionMobile.Views;

public partial class KeywordsPage : ContentPage
{
    KeywordViewModel viewModel;

    public KeywordsPage(KeywordViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
        this.viewModel= viewModel;

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetKeywordsCommand.Execute(this);
    }
}