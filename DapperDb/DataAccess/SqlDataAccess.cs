using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Database.Models.Domain;

namespace Database.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;  
        }

        public async Task<IEnumerable<T>> GetData<T ,P>(string spName , P parameters ,string ConnectionId = "conn")
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString(ConnectionId));
            return await connection.QueryAsync<T>(spName, parameters, commandType:           CommandType.StoredProcedure);

        }

        public async Task SaveData<T>(string spName , T parameters , string connectionId = "conn")
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(spName ,parameters , commandType:
                CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Person>> GetPeople(string query)
        {
           

            using IDbConnection connection = new SqlConnection(
               _config.GetConnectionString("conn"));

            var companies = await connection.QueryAsync<Person>(query);
                return companies.ToList();
            
        }
    }
}
