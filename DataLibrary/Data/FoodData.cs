using DataLibrary.Db;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly ISql _db;
        private readonly ConnectionStringData _connectionString;

        //ctor

        public FoodData(ISql db, ConnectionStringData connectionString)
        {
            _db = db;
            _connectionString = connectionString;
        }

        // GetFood

        public async Task<List<FoodModel>> GetFood()
        {
            return await _db.LoadData<FoodModel, dynamic>("dbo.spFood_All",
                                                          new { },
                                                          _connectionString.ConnectionStringName);
        }
    }
}
