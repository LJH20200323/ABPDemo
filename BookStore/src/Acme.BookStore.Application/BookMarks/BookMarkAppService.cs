using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace Acme.BookStore.BookMarks
{
    [Authorize(BookStorePermissions.BookMarks.Default)]
    public class BookMarkAppService :
        CrudAppService<BookMark, BookMarkDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookMarkDto>
        , IBookMarkAppService
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        #region 
        public BookMarkAppService(IRepository<BookMark, Guid> repository, IRepository<Book, Guid> bookRepository) : base(repository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// 根据书签ID获取书签实体并生成BookMarkDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<BookMarkDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();
            var quer = from bookMark in queryable
                       join book in _bookRepository on bookMark.BookId equals book.Id
                       where bookMark.Id == id
                       select new { bookMark, book };
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(quer);
            if (queryResult == null)
                throw new EntityNotFoundException(typeof(BookMark), id);
            var bookMarkdto = ObjectMapper.Map<BookMark, BookMarkDto>(queryResult.bookMark);
            bookMarkdto.BookName = queryResult.book.Name;
            return bookMarkdto;
        }

        /// <summary>
        /// 根据查询条件获取书签实体集并生成BookMarkDto集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PagedResultDto<BookMarkDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();
            var query = from bookMark in queryable
                        join book in _bookRepository on bookMark.BookId equals book.Id
                        select new { bookMark, book };
            query = query.OrderBy(NormalizeSorting(input.Sorting)).Skip(input.SkipCount).Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(query);
            var bookMarkDtos = queryResult.Select(x =>
            {
                var bookMarkDto = ObjectMapper.Map<BookMark, BookMarkDto>(x.bookMark);
                bookMarkDto.BookName = x.book.Name;
                return bookMarkDto;
            }).ToList();
            var totalCount = await Repository.GetCountAsync();
            return new PagedResultDto<BookMarkDto>(totalCount, bookMarkDtos); ;
        }

        /// <summary>
        /// 处理排序字符串
        /// </summary>
        /// <param name="sorting">排序字符串</param>
        /// <returns></returns>
        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
                return $"bookMark.{nameof(Book.Name)}";
            if (sorting.Contains("bookName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace("bookName", "book.Name", StringComparison.OrdinalIgnoreCase);
            }
            return $"bookMark.{sorting}";
        }
        #endregion

        /// <summary>
        /// 获取书籍名称
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<BookLookUpDto>> GetBookLookUpAsync()
        {
            var books = await _bookRepository.GetListAsync();
            return new ListResultDto<BookLookUpDto>(ObjectMapper.Map<List<Book>, List<BookLookUpDto>>(books));
        }
    }
}
