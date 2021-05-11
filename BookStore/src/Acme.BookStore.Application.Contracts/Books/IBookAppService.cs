using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>
    {
        /// <summary>
        /// 获取作者名称
        /// </summary>
        /// <returns>返回AuthorLookupDto集合</returns>
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}
