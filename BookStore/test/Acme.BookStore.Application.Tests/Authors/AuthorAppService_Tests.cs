using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.BookStore.Authors
{
    public class AuthorAppService_Tests: BookStoreApplicationTestBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorAppService_Tests()
        {
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        /// <summary>
        /// 查询所有作者数据单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Get_All_Authors_Without_Any_Filter()
        {
            var result = await _authorAppService.GetListAsync(new GetAuthorListDto());
            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(x => x.Name == "Li");
            result.Items.ShouldContain(x => x.Name == "Jun");
        }

        /// <summary>
        /// 条件查询作者数据单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Get_Filtered_Authors()
        {
            var result = await _authorAppService.GetListAsync(new GetAuthorListDto() {Filter="Li" });
            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(x => x.Name == "Li");
            result.Items.ShouldNotContain(x => x.Name == "Jun");
        }

        /// <summary>
        /// 创建新作者数据 单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Create_A_New_Author()
        {
            var authorDto = await _authorAppService.CreateAsync(new CreateAuthorDto()
            {
                Name = "Edward Bellamy",
                BirthDate = new DateTime(1850, 05, 22),
                ShortBio = "Edward Bellamy was an American author..."
            });

            authorDto.Id.ShouldNotBe(Guid.Empty);
            authorDto.Name.ShouldBe("Edward Bellamy");
        }

        /// <summary>
        /// 异常提示验证单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Author()
        {
            await Assert.ThrowsAsync<AuthorAlreadyExistsException>(async () =>
            {
                await _authorAppService.CreateAsync(
                    new CreateAuthorDto
                    {
                        Name = "Douglas Adams",
                        BirthDate = DateTime.Now,
                        ShortBio = "..."
                    }
                );
            });
        }
        
    }
}
