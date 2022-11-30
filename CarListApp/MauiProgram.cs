using CarListApp.Pages;
using CarListApp.Services;
using CarListApp.ViewModels;

namespace CarListApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbpath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");
		builder.Services.AddSingleton(s=>ActivatorUtilities.CreateInstance<CarService>(s,dbpath));


		builder.Services.AddSingleton<CarListViewModel>();
		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<CarDetailsPage>();
		builder.Services.AddTransient<CarDetailsViewModel>();

        return builder.Build();
	}
}
