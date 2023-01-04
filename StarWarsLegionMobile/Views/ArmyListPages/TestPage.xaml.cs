namespace StarWarsLegionMobile.Views;


	
public partial class TestPage : ContentPage
{

    public TestPage(TestViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}

}