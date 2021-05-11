using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.BookMarks
{
     public class BookLookUpDto : EntityDto<Guid>
    {
        /// <summary>
        /// 书籍名称
        /// </summary>
        public string Name { get; set; }
    }
}
