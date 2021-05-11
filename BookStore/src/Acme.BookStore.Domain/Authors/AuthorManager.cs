using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors
{
    public class AuthorManager : DomainService
    {
        private readonly IAuthorRepository _authorRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authorRepository">作者表数据仓库</param>
        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// 异步创建作者表实体
        /// </summary>
        /// <param name="name">作者名称</param>
        /// <param name="birthDate">出生日期</param>
        /// <param name="shortBio">简介</param>
        /// <returns></returns>
        public async Task<Author> CreateAsync([NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            var existingAuthor = await _authorRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Author(
                GuidGenerator.Create(),
                name,
                birthDate,
                shortBio
            );
        }

        /// <summary>
        /// 异步更新作者名称
        /// </summary>
        /// <param name="author"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public async Task ChangeNameAsync([NotNull] Author author, [NotNull] string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));
            var existingAuthor = await _authorRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != author.Id)
                throw new AuthorAlreadyExistsException(newName);
            author.ChangeName(newName);
        }
    }
}
