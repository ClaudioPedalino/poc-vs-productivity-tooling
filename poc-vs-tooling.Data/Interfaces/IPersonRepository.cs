using poc_vs_tooling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Data.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(Guid entityId);
        void Create(Person entity);
        void Delete(Person test); //[CP] rename to match implementation
    }
}
