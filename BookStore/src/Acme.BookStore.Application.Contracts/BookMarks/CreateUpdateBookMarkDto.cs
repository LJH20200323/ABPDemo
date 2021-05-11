using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.BookMarks
{
    public class CreateUpdateBookMarkDto
    {
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
        public Guid BookId { get; set; }

    }
}
