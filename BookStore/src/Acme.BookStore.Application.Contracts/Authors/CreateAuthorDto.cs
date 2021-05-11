using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Authors
{
    public class CreateAuthorDto
    {
        /// <summary>
        /// 作者名称
        /// 非空/最大长度为AuthorConsts.MaxNameLength
        /// </summary>
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 出生日期
        /// 非空
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string ShortBio { get; set; }
    }
}
