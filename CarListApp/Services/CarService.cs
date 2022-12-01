using CarListApp.Models;
using SQLite;
   
namespace CarListApp.Services
{
    public class CarService
    {
        SQLiteConnection connection;
        string _dbPath;
        public string StatusMessage;
        int result= 0;

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

        public void AddCar(Cars car) 
        {
            try
            {
                Init();
                if(car is null) 
                throw new Exception("Ivalid Car Record");

                result=connection.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "InsertSucessFul";


            }
            catch (Exception ex)
            {
                StatusMessage = "Filed to insert data";
              
            }
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();
                return connection.Table<Cars>().Delete(q=>q.Id==id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data";
                throw;
            }
            return 0;
        }
    }
}
