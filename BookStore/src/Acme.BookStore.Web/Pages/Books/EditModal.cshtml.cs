using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Acme.BookStore.Books;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Acme.BookStore.Web.Pages.Books
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditBookViewModel Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public List<SelectListItem> Authors { get; set; }

        public EditModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var bookDto = await _bookAppService.GetAsync(id);
            Book = ObjectMapper.Map<BookDto, EditBookViewModel>(bookDto);
            var authorLookup = await _bookAppService.GetAuthorLookupAsync();
            Authors = authorLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Book.Id, ObjectMapper.Map<EditBookViewModel, CreateUpdateBookDto>(Book));
            return NoContent();
        }

        /// <summary>
        /// 修改界面实体
        /// </summary>
        public class EditBookViewModel
        {
            /// <summary>
            /// 书籍ID（修改界面实体不可缺少）
            /// </summary>
            [HiddenInput]
            public Guid Id { get; set; }

            /// <summary>
            /// 作者ID
            /// </summary>
            [SelectItems(nameof(Authors))]
            [DisplayName("Author")]
            public Guid AuthorId { get; set; }

            /// <summary>
            /// 书籍名称
            /// </summary>
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            /// <summary>
            /// 书籍类型
            /// </summary>
            [Required]
            public BookType Type { get; set; } = BookType.Undefined;

            /// <summary>
            /// 发布时间
            /// </summary>
            [Required]
            [DataType(DataType.Date)]
            public DateTime PublishDate { get; set; } = DateTime.Now;

            /// <summary>
            /// 价格
            /// </summary>
            [Required]
            public float Price { get; set; }

            /// <summary>
            /// 是否可用
            /// 非空/控件默认值（True或0）
            /// </summary>
            [Required]
            public BookIsTrue IsTrue { get; set; } = BookIsTrue.True;
        }
    }
}
