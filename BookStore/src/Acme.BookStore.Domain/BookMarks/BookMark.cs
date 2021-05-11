using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.BookMarks
{
    public class BookMark : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 书签名称
        /// </summary>
        [MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 书签内容
        /// </summary>
        [MaxLength(3000)]
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

    }
}
