using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public interface ISql
    {
        Task<List<T>> LoadData<T,U>(string storeProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<U>(string storeprocedure, U parameters, string connectionStringname);
    }
}
