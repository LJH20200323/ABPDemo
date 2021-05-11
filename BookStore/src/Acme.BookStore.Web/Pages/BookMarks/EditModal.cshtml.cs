using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.BookMarks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.BookMarks
{
    public class EditModalModel : BookStorePageModel
    {

        [BindProperty]
        public EditBookMarkViewModel BookMark { get; set; }

        private readonly IBookMarkAppService _bookMarkAppService;

        public List<SelectListItem> Books { get; set; }

        public EditModalModel(IBookMarkAppService bookMarkAppService)
        {
            _bookMarkAppService = bookMarkAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var bookMarkDto = await _bookMarkAppService.GetAsync(id);
            BookMark = ObjectMapper.Map<BookMarkDto, EditBookMarkViewModel>(bookMarkDto);
            var bookLookup = await _bookMarkAppService.GetBookLookUpAsync();
            Books = bookLookup.Items.Select(x=>new SelectListItem (x.Name,x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookMarkAppService.UpdateAsync(BookMark.Id,ObjectMapper.Map<EditBookMarkViewModel,CreateUpdateBookMarkDto>(BookMark));
            return NoContent();
        }

        public class EditBookMarkViewModel
        {
            /// <summary>
            /// 书籍ID（修改界面实体不可缺少）
            /// </summary>
            [HiddenInput]
            public Guid Id { get; set; }

            /// <summary>
            /// 书签名称
            /// </summary>
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            /// <summary>
            /// 书签内容
            /// </summary>
            [Required]
            public string BookMarkContent { get; set; }

            /// <summary>
            /// 内容长度
            /// </summary>
            public long ContentLength { get; set; }

            /// <summary>
            /// 页码
            /// </summary>
            [Required]
            public int PageNum { get; set; }

            /// <summary>
            /// 行数
            /// </summary>
            [Required]
            public int RowNum { get; set; }

            /// <summary>
            /// 起始字数
            /// </summary>
            [Required]
            public int StartingWordNum { get; set; }

            /// <summary>
            /// 书籍ID
            /// </summary>
            [SelectItems(nameof(Books))]
            [DisplayName("Book")]
            public Guid BookId { get; set; }
        }
    }
}
