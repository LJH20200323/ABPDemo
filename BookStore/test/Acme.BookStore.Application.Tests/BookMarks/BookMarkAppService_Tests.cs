using Acme.BookStore.Books;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.BookStore.BookMarks
{
   public class BookMarkAppService_Tests: BookStoreApplicationTestBase
    {
        private readonly IBookMarkAppService  _bookMarkAppService;
        private readonly IBookAppService  _bookAppService;

        public BookMarkAppService_Tests()
        {
            _bookMarkAppService = GetRequiredService<IBookMarkAppService>();
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        /// <summary>
        /// 查询单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Get_List_Of_BookMarks()
        {
            var result = await _bookMarkAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
                );
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(x => x.Name == "testBookMark" && x.BookName == "2021荒岛日记");
        }

        /// <summary>
        /// 创建单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Create_A_Valid_BookMark()
        {
            var books = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            var firstAuthor = books.Items.First();

            string bookMarkContent = "sfsagsagsdgsahsa";

            var result = await _bookMarkAppService.CreateAsync(new CreateUpdateBookMarkDto()
            {
                BookId = firstAuthor.Id,
                Name = "荒岛日记书签",
                BookMarkContent = bookMarkContent,
                ContentLength = bookMarkContent.Length,
                PageNum = 1,
                RowNum = 20,
                StartingWordNum = 4,
            });
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("荒岛日记书签");
        }

        /// <summary>
        /// Abp异常提示单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Not_Create_A_BookMark_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () => {
                await _bookAppService.CreateAsync(
                new CreateUpdateBookDto()
                {
                    Name = "",
                    Type = BookType.ScienceFiction,
                    PublishDate = DateTime.Now,
                    Price = 11,
                });
            });

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
