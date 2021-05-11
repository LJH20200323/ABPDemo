using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.BookMarks
{
    public class BookMarkDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 书签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 书签内容
        /// </summary>
        public string BookMarkContent { get; set; }

        /// <summary>
        /// 内容长度
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageNum { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int RowNum { get; set; }

        /// <summary>
        /// 起始字数
        /// </summary>
        public int StartingWordNum { get; set; }

        /// <summary>
        /// 书籍ID
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// 书籍名称
        /// </summary>
        public string BookName { get; set; }

    }
}
