using Database.Models.Domain;
using System.Data;

namespace Database.Repository
{
    public interface IPersonRepository
    {
        Task<bool> AddAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task<IEnumerable<Person>> GetAllAsync();
      
    }
}