using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Books
{
    public class CreateUpdateBookDto
    {
        /// <summary>
        /// 名称
        /// 非空 字段最大长度128
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 书本类型
        /// 非空/控件默认值（Undefined或0）
        /// </summary>
        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        /// <summary>
        /// 发布日期
        /// 非空/日期控件类型为Date类型，默认值为当天
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 价格
        /// 非空
        /// </summary>
        [Required]
        public float Price { get; set; }

        /// <summary>
        /// 是否可用
        /// 非空/控件默认值（True或0）
        /// </summary>
        [Required]
        public BookIsTrue IsTrue { get; set; } = BookIsTrue.True;

        /// <summary>
        /// 作者ID
        /// </summary>
        public Guid AuthorId { get; set; }

    }
}
