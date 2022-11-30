﻿using CarListApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Cars), "Cars")]
    public partial class CarDetailsViewModel :BaseViewModel
    {
        [ObservableProperty]
        Cars cars;
    }
}
