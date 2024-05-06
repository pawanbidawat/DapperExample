using Database.DataAccess;
using Database.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{

    public class PersonRepository : IPersonRepository
    {
        private readonly ISqlDataAccess _db;
        public PersonRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Person person)
        {
            try
            {
                await _db.SaveData("sp_create_person" , new {person.Name ,person.Email , person.Address});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        } 

        public async Task<bool> UpdateAsync(Person person)
        {
            try
            {
                await _db.SaveData("sp_update_person", person);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            string query = "Select * from [Person]";
            return await _db.GetPeople(query);


        }
    }
}
