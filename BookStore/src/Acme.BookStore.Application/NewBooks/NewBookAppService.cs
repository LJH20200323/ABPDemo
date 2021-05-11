using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.NewBooks
{
    public class NewBookAppService : ApplicationService, INewBookAppService
    {
        private readonly IRepository<NewBook, Guid> _newBookRepository;

        public NewBookAppService(IRepository<NewBook, Guid> newBookRepository)
        {
            _newBookRepository = newBookRepository;
        }


        public async Task CreateAsync(CreateNewBookDto input)
        {
            var newBook = new NewBook(GuidGenerator.Create(),input.Name,input.Type,input.Price);
            await _newBookRepository.InsertAsync(newBook);
        }

        public async Task<NewBookDto> GetAsync(Guid id)
        {
            var newBook = await _newBookRepository.GetAsync(id);
            return ObjectMapper.Map<NewBook, NewBookDto>(newBook);
        }
    }
}
