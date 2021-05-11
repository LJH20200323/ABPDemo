using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Persons
{
    public interface IPersonRepository:IRepository<Person, Guid>
    {

        Task<Person> FindByNameAsync(string name);
    }
}
