using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ListResultDto<ProductDto>> GetListAsync(string name);
    }
}
