using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class AuthorDto: EntityDto<Guid>
    {
        /// <summary>
        /// 作者名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string ShortBio { get; set; }
    }
}
