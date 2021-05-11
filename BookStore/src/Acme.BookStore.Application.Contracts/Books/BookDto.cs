using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books
{
    public class BookDto: AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 书籍类型
        /// </summary>
        public BookType Type { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public BookIsTrue IsTrue { get; set; }


        public Guid AuthorId { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }
    }
}
