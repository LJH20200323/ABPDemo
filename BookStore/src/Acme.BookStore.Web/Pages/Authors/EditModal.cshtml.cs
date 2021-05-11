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
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditAuthorViewModel Author { get; set; }

        private readonly IAuthorAppService _authorAppService;

        public EditModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var authorDto = await _authorAppService.GetAsync(id);
            Author = ObjectMapper.Map<AuthorDto, EditAuthorViewModel>(authorDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorAppService.UpdateAsync(Author.Id,ObjectMapper.Map<EditAuthorViewModel, UpdateAuthorDto>(Author));
            return NoContent();
        }

        /// <summary>
        /// �����޸Ľ���ʵ��
        /// </summary>
        public class EditAuthorViewModel
        {
            /// <summary>
            /// ����ID�����
            /// </summary>
            [HiddenInput]
            public Guid Id { get; set; }

            /// <summary>
            /// ����
            /// </summary>
            [Required]
            [StringLength(AuthorConsts.MaxNameLength)]
            public string Name { get; set; }

            /// <summary>
            /// ��������
            /// </summary>
            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            /// <summary>
            /// ���
            /// </summary>
            [TextArea]
            public string ShortBio { get; set; }
        }
    }
}
