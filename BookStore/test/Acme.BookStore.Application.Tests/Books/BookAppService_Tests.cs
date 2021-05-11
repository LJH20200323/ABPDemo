using Acme.BookStore.Authors;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.BookStore.Books
{
    public class BookAppService_Tests:BookStoreApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IAuthorAppService _authorAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        /// <summary>
        /// 查询单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await _bookAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
                );
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(x=>x.Name== "2021荒岛日记"&&x.AuthorName=="Li");
        }

        /// <summary>
        /// 创建单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Create_A_Valid_Book()
        {
            var authors = await _authorAppService.GetListAsync(new GetAuthorListDto());
            var firstAuthor = authors.Items.First();

            var result = await _bookAppService.CreateAsync(new CreateUpdateBookDto()
            {
                AuthorId = firstAuthor.Id,
                Name = "2021科幻之旅",
                Type = BookType.ScienceFiction,
                PublishDate = DateTime.Now,
                Price = 11,
                IsTrue=BookIsTrue.True

            });
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("2021科幻之旅");
        }

        /// <summary>
        /// Abp异常提示单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async ()=> {
                await _bookAppService.CreateAsync(
                new CreateUpdateBookDto()
                {
                    Name = "",
                    Type = BookType.ScienceFiction,
                    PublishDate = DateTime.Now,
                    Price = 11,
                    IsTrue = BookIsTrue.True
                });
            });

            exception.ValidationErrors.ShouldContain(err=>err.MemberNames.Any(mem => mem=="Name"));
        }
    }
}
