using Bank.Details.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Details.Data.Repositories
{
    public class DataRepo : IDataRepo
    {
        private readonly DbConnection _dbConnection;

        public DataRepo()
        {
            _dbConnection = new SqlConnection(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Data\\Test Projects\\mkaur24\\backend\\Bank.Details.Repository\\Bank.mdf\";Integrated Security=True");
        }

        private DynamicParameters PrepareParameters(Dictionary<string, object> paramObjects)
        {
            var parameters = new DynamicParameters();
            paramObjects.ToList().ForEach(x => parameters.Add($"?{x.Key}", x.Value));

            return parameters;
        }

        public async Task DeleteDetails(int id)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var result = await _dbConnection.QueryAsync($"DELETE FROM BankInfo WHERE Id = {id}");
                _dbConnection.Close();
            }
        }

        public async Task<List<T>> GetAllDetails<T>()
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<T>("SELECT * FROM BankInfo");
                _dbConnection.Close();

                return result.ToList();
            }
        }

        public async Task<T> GetData<T>(int id) where T : class, new()
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var result = await _dbConnection.QueryFirstAsync<T>($"SELECT * FROM BankInfo WHERE Id = {id}");
                _dbConnection.Close();

                return result;
            }
        }

        public async Task SaveDetails(string spName, Dictionary<string, object> parameters)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var result = await _dbConnection.QueryAsync(sql: spName,
                    param: PrepareParameters(parameters),
                    commandType: CommandType.StoredProcedure);

                _dbConnection.Close();
            }
        }

        public async Task UpdateDetails(string spName, Dictionary<string, object> parameters)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var result = await _dbConnection.QueryAsync(sql: spName,
                    param: PrepareParameters(parameters),
                    commandType: CommandType.StoredProcedure);

                _dbConnection.Close();
            }
        }

        public async Task<List<T>> GetDataBySql<T>(string sql)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<T>(sql);
                _dbConnection.Close();

                return result.ToList();
            }
        }
    }
}
