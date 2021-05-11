using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Authors
{
    [Authorize(BookStorePermissions.Authors.Default)]
    public class AuthorAppService : BookStoreAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;

        private readonly AuthorManager _authorManager;

        public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
        {
            _authorManager = authorManager;
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// 创建作者Dto创建实体
        /// </summary>
        /// <param name="input">作者Dto创建实体</param>
        /// <returns>作者Dto实体</returns>
        [Authorize(BookStorePermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(input.Name, input.BirthDate, input.ShortBio);
            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);

        }

        /// <summary>
        /// 根据作者ID删除作者
        /// </summary>
        /// <param name="id">作者Id</param>
        /// <returns>无</returns>
        [Authorize(BookStorePermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 根据作者ID查询作者数据
        /// </summary>
        /// <param name="id">作者ID</param>
        /// <returns>作者实体</returns>
        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        /// <summary>
        /// 根据查询条件查询作者数据
        /// 模糊查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns>区间数据</returns>
        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Author.Name);

            var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(x => x.Name.Contains(input.Filter));
            return new PagedResultDto<AuthorDto>(totalCount, ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));
        }

        /// <summary>
        /// 创建作者Dto修改实体
        /// </summary>
        /// <param name="id">作者ID</param>
        /// <param name="input">作者Dto修改实体</param>
        /// <returns>无</returns>
        [Authorize(BookStorePermissions.Authors.Update)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);
            if (author.Name!=input.Name)
            {
                await _authorManager.ChangeNameAsync(author,input.Name);
            }
            author.Name = input.Name;
            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }
    }
}
