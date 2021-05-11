using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Persons
{
    public class PersonRepository : EfCoreRepository<BookStoreDbContext, Person, Guid>, IPersonRepository
    {
        public PersonRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider):base(dbContextProvider)
        {

        }

        public async Task<Person> FindByNameAsync(string name)
        {
            return await DbContext.Set<Person>().Where(p => p.Name == name).FirstOrDefaultAsync();
        }
    }
}
