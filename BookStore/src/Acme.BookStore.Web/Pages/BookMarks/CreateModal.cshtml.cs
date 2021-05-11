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
    public class CreateModalModel : BookStorePageModel
    {

        [BindProperty]
        public CreateBookMarkViewModel BookMark { get; set; }

        public List<SelectListItem> Books { get; set; }

        private readonly IBookMarkAppService _bookMarkAppService;

        public CreateModalModel(IBookMarkAppService bookMarkAppServer)
        {
            _bookMarkAppService = bookMarkAppServer;
        }

        public async Task OnGetAsync()
        {
            BookMark = new CreateBookMarkViewModel();
            var bookLooup = await _bookMarkAppService.GetBookLookUpAsync();
            Books = bookLooup.Items.Select(x=>new SelectListItem (x.Name,x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateBookMarkViewModel, CreateUpdateBookMarkDto>(BookMark);
            await _bookMarkAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateBookMarkViewModel {
            /// <summary>
            /// ��ǩ����
            /// </summary>
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            /// <summary>
            /// ��ǩ����
            /// </summary>
            [Required]
            public string BookMarkContent { get; set; }

            /// <summary>
            /// ���ݳ���
            /// </summary>
            public long ContentLength { get; set; }

            /// <summary>
            /// ҳ��
            /// </summary>
            [Required]
            public int PageNum { get; set; } = 1;

            /// <summary>
            /// ����
            /// </summary>
            [Required]
            public int RowNum { get; set; } = 1;

            /// <summary>
            /// ��ʼ����
            /// </summary>
            [Required]
            public int StartingWordNum { get; set; } = 1;

            /// <summary>
            /// �鼮ID
            /// </summary>
            [SelectItems(nameof(Books))]
            [DisplayName("Book")]
            public Guid BookId { get; set; }
        }
    }
}
