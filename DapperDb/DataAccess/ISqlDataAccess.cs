using Database.Models.Domain;

namespace Database.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string ConnectionId = "conn");

        Task SaveData<T>(string spName, T parameters, string connectionId = "conn");
        Task<IEnumerable<Person>> GetPeople(string query);
    }
}