using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateModalModel : BookStorePageModel
    {
        public CreateBookViewModel Book { get; set; }

        public List<SelectListItem> Authors { get; set; }

        private readonly IBookAppService _bookAppService;

        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync()
        {
            Book = new CreateBookViewModel();
            var authorLookup = await _bookAppService.GetAuthorLookupAsync();
            Authors = authorLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(ObjectMapper.Map<CreateBookViewModel, CreateUpdateBookDto>(Book));
            return NoContent();
        }

        /// <summary>
        /// ����ҳ�����ʵ��
        /// </summary>
        public class CreateBookViewModel
        {
            /// <summary>
            /// ����ID
            /// </summary>
            [SelectItems(nameof(Authors))]
            [DisplayName("Author")]
            public Guid AuthorId { get; set; }

            /// <summary>
            /// �鼮����
            /// </summary>
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            /// <summary>
            /// �鼮����
            /// </summary>
            [Required]
            public BookType Type { get; set; } = BookType.Undefined;

            /// <summary>
            /// ����ʱ��
            /// </summary>
            [Required]
            [DataType(DataType.Date)]
            public DateTime PublishDate { get; set; } = DateTime.Now;

            /// <summary>
            /// �۸�
            /// </summary>
            [Required]
            public float Price { get; set; }

            /// <summary>
            /// �Ƿ����
            /// �ǿ�/�ؼ�Ĭ��ֵ��True��0��
            /// </summary>
            [Required]
            public BookIsTrue IsTrue { get; set; } = BookIsTrue.True;
        }
    }
}
