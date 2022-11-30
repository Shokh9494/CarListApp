using CarListApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Services
{
    public class CarService
    {
        SQLiteConnection connection;
        string _dbPath;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (connection != null) return;
            connection = new SQLiteConnection(_dbPath);
            connection.CreateTable<Cars>();
        }
        public async Task<List<Cars>> GetCarsAsysn()
        {
            try
            {
                Init();

            }
            catch (Exception ex)
            {

                throw;
            }
            return new List<Cars>();
        }
    }
}
