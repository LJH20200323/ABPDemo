using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Persons
{
    public class PersonAppService: ApplicationService
    {
        private readonly IRepository<Person, Guid> _personRepository;

        public PersonAppService(IRepository<Person, Guid> personRepository)
        {
            _personRepository = personRepository;
        }

       public async Task Create(CreatePersonDto input)
        {
            var person = new Person() { Name = input.Name,Age=input.Age };
            await _personRepository.InsertAsync(person);
        }

        public List<PersonDto> GetList(string nameFilter)
        {
            var people = _personRepository.Where(x => x.Name.Contains(nameFilter)).ToList();
            return people.Select(p => new PersonDto { Id = p.Id, Name = p.Name, Age = p.Age }).ToList();
        }
    }
}
