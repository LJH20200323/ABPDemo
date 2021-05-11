using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Filter { get; set; }
    }
}
