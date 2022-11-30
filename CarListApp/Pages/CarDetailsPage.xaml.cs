using CarListApp.ViewModels;

namespace CarListApp.Pages;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage(CarDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}