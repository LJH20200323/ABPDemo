using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    /// <summary>
    /// 书籍实体类
    /// </summary>
    public class Book : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 书本类型
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

        /// <summary>
        /// 主从表关联(外键作者ID)
        /// </summary>
        public Guid AuthorId { get; set; }
    }
}
