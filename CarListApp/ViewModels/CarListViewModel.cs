using CarListApp.Models;
using CarListApp.Services;
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
    public partial class CarListViewModel :BaseViewModel
    {
        private readonly CarService carService;
        public ObservableCollection<Cars> cars { get; private set; } = new();
        public CarListViewModel(CarService carService)
        {
            Title = "Car lisr";
            this.carService=carService;
        }

        [RelayCommand]
        async Task GetCarList()
        {
            if(IsLoading) return;
            try
            {
                IsLoading= true;
                if(cars.Any()) cars.Clear();
                var car = await carService.GetCarsAsysn();
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
            }
        }
    }
}
