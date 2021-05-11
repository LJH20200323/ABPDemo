using Acme.BookStore.Authors;
using Acme.BookStore.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Acme.BookStore.Books
{
    public class BookAppService : CrudAppService<Book, BookDto,Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>, IBookAppService
    {
        private readonly IAuthorRepository _authorRepository;
        public BookAppService(IRepository<Book,Guid> repository, IAuthorRepository authorRepository)
            : base(repository)
        {
            _authorRepository = authorRepository;
            GetPolicyName = BookStorePermissions.Books.Default;
            GetListPolicyName = BookStorePermissions.Books.Default;
            CreatePolicyName = BookStorePermissions.Books.Create;
            UpdatePolicyName = BookStorePermissions.Books.Edit;
            DeletePolicyName = BookStorePermissions.Books.Delete;
        }

        /// <summary>
        /// 根据书籍ID获取书籍实体并生成BookDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<BookDto> GetAsync(Guid id)
        {
            /*Repository 作用于TEntity*/
            var queryable = await Repository.GetQueryableAsync();
            var query = from book in queryable
                        join author in _authorRepository on book.AuthorId equals author.Id
                        where book.Id == id
                        select new { book, author };
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
                throw new EntityNotFoundException(typeof(Book),id);
            var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult.book);
            bookDto.AuthorName = queryResult.author.Name;
            return bookDto;
        }

        /// <summary>
        /// 根据查询条件获取书籍实体集并生成BookDto集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();
            var query = from book in queryable
                        join author in _authorRepository on book.AuthorId equals author.Id
                        select new { book, author };
            query = query.OrderBy(NormalizeSorting(input.Sorting)).Skip(input.SkipCount).Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(query);
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();
            var totalCount = await Repository.GetCountAsync();
            return new PagedResultDto<BookDto> (totalCount,bookDtos);
        }

        /// <summary>
        /// 处理排序字符串
        /// </summary>
        /// <param name="sorting">排序字符串</param>
        /// <returns></returns>
        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
                return $"book.{nameof(Book.Name)}";
            if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace("authorName", "author.Name",StringComparison.OrdinalIgnoreCase);
            }
            return $"book.{sorting}";
        }

        /// <summary>
        /// 获取作者名称
        /// </summary>
        /// <returns>返回AuthorLookupDto集合</returns>
        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authors = await _authorRepository.GetListAsync();
            return new ListResultDto<AuthorLookupDto>(ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors));
        }
    }
}
