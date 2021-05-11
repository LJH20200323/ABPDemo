using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.BookMarks
{
    public interface IBookMarkAppService : 
        ICrudAppService<BookMarkDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookMarkDto>
    {
        /// <summary>
        /// 获取书籍名称
        /// </summary>
        /// <returns>返回BookLookUpDto集合</returns>
        Task<ListResultDto<BookLookUpDto>> GetBookLookUpAsync();

    }
}
