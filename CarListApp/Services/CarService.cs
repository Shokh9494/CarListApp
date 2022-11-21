using CarListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Services
{
    public class CarService
    {
        public async Task<List<Cars>> GetCarsAsysn()
        {
            return new List<Cars>()
            {
                new Cars
                {
                    Id=1,
                    Make="Honda",
                    Model="Fit",
                    Vin="123"
                },
                 new Cars
                {
                    Id=2,
                    Make="Spark",
                    Model="Fit",
                    Vin="123"
                },
                  new Cars
                {
                    Id=3,
                    Make="Nexia",
                    Model="Fit",
                    Vin="123"
                },
                   new Cars
                {
                    Id=4,
                    Make="Gentra",
                    Model="Fit",
                    Vin="123"
                }

            };                 
        }
    }
}
