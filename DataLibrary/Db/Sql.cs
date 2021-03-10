using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class Sql : ISql
    {
        private readonly IConfiguration _config;

        public Sql(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storeProcedure,
                                                  U parameters,
                                                  string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);            

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                var records = await connection.QueryAsync<T>(storeProcedure,
                                                             parameters,
                                                             commandType: CommandType.StoredProcedure);

                return records.ToList();
            }
        }

        public async Task<int> SaveData<U>(string storeProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionStringName))
            {
                return await connection.ExecuteAsync(storeProcedure,
                                                     parameters,
                                                     commandType: CommandType.StoredProcedure);
            }
        }
    }
}
