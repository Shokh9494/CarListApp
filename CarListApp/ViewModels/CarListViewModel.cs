using CarListApp.Models;
using CarListApp.Pages;
using CarListApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModels
{
    public partial class CarListViewModel : BaseViewModel
    {
        public ObservableCollection<Cars> cars { get; private set; } = new();
        public CarListViewModel()
        {
            Title = "Car lisr";
            GetCarList().Wait();
        }

        [ObservableProperty]
        string make;
        [ObservableProperty]
        string model;
        [ObservableProperty]
        string vin;
       

        [RelayCommand]
        async Task GetCarList()
        {
            
            if(IsLoading) return;
            try
            {
                IsLoading= true;
                if(cars.Any()) cars.Clear();
                var car = await App.CarService.GetCarsAsysn();
                foreach (var item in car)
                {
                    cars.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await  Shell.Current.DisplayAlert("Error", $"error is {ex.Message}", "ok");
            }
            finally
            {
                IsLoading= false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GetCarDetails(Cars cars)
        {
            if (cars == null) return;
            await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>
            {
                { nameof(Cars),cars}
            });
        }

        [RelayCommand]
        async Task AddCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }
            var car = new Cars
            {
                Make = Make,
                Model = Model,
                Vin = Vin,
            };
            App.CarService.AddCar(car);
            await Shell.Current.DisplayAlert("Sucesss", App.CarService.StatusMessage, "Ok");
            await GetCarList();
        }

        [RelayCommand]
        async Task DeleteCar(int id)
        {
            if(id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Recor", "PleaseTryagain", "Ok");
                return;
            }
            var result = App.CarService.DeleteCar(id);
            if (result == 0) await Shell.Current.DisplayAlert("Info", "Please insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Deletion Sucessful", "Record remove Sucessfully", "Ok");
                await GetCarList();
            }

        }

        }
    }
