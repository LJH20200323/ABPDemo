using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Authors
{
    public class CreateModalModel : BookStorePageModel
    {
        /// <summary>
        /// 界面实体，体现界面输入数据
        /// </summary>
        [BindProperty]
        public CreateAuthorViewModel Author { get; set; }

        private readonly IAuthorAppService _authorAppService;

        public CreateModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public void OnGet()
        {
            Author = new CreateAuthorViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateAuthorViewModel, CreateAuthorDto>(Author);
            await _authorAppService.CreateAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// 作者创建界面实体
        /// </summary>
        public class CreateAuthorViewModel
        {
            /// <summary>
            /// 作者
            /// </summary>
            [Required]
            [StringLength(AuthorConsts.MaxNameLength)]
            public string Name { get; set; }

            /// <summary>
            /// 出生日期
            /// </summary>
            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            /// <summary>
            /// 简介
            /// </summary>
            [TextArea]
            public string ShortBio { get; set; }
        }
    }
}
