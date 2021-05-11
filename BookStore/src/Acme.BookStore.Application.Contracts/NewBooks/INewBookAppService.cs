using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.NewBooks
{
    public interface INewBookAppService: IApplicationService
    {
        Task CreateAsync(CreateNewBookDto input);

        Task<NewBookDto> GetAsync(Guid id);
    }
}
