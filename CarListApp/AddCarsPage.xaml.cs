using CarListApp.ViewModels;

namespace CarListApp;

public partial class AddCarsPage : ContentPage
{
	public AddCarsPage(CarListViewModel carListViewModel)
	{
		InitializeComponent();
        BindingContext = carListViewModel;
    }
}