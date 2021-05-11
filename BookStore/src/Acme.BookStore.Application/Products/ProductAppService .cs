using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace Acme.BookStore.Products
{
    class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public ProductAppService(IRepository<Product, Guid> productRepository, IAsyncQueryableExecuter asyncExecuter)
        {
            _productRepository = productRepository;
            _asyncExecuter = asyncExecuter;
        }

        public async Task<ListResultDto<ProductDto>> GetListAsync(string name)
        {
            var query = _productRepository.Where(x => x.name.Contains(name)).OrderBy(x=>x.name);

           List<Product> products = await _asyncExecuter.ToListAsync(query);

           return new ListResultDto<ProductDto>(ObjectMapper.Map<List<Product>,List<ProductDto>>(products));
        }
    }
}
