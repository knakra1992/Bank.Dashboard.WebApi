using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Details.Data.Interfaces
{
    public interface IDataRepo
    {
        Task<T> GetData<T>(int id) where T : class, new();

        Task<List<T>> GetAllDetails<T>();

        Task SaveDetails(string spName, Dictionary<string, object> parameters);

        Task UpdateDetails(string spName, Dictionary<string, object> parameters);

        Task DeleteDetails(int id);

        Task<List<T>> GetDataBySql<T>(string sql);
    }
}
