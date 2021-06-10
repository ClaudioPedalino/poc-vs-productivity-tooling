using Microsoft.EntityFrameworkCore;
using poc_vs_tooling.Core.Entities;
using poc_vs_tooling.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_vs_tooling.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _dataContext;

        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<Person> GetAll()
        {
            return _dataContext.Persons.Where(x => x.DeleteAt == null).AsNoTracking();
        }


        public Person GetById(Guid entityId)
        {
            return _dataContext.Persons.FirstOrDefault(x => x.PersonId == entityId);
        }


        public void Create(Person entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }


        public void Delete(Person entity)
        {
            entity.DeleteAt = DateTime.UtcNow.AddHours(-3);
            _dataContext.SaveChanges();
        }
        
    }
}
