using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors
{
    /// <summary>
    /// 作者实体类
    /// </summary>
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 作者
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

        /// <summary>
        /// 生成作都表实体
        /// </summary>
        /// <param name="id">作者ID</param>
        /// <param name="name">作者名称</param>
        /// <param name="birthDate">出生日期</param>
        /// <param name="shortBio">简介</param>
        internal Author(Guid id, [NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio = null) : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

        /// <summary>
        /// 更改作者名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal Author ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        /// <summary>
        /// 设置作者名称,名称默认值为name
        /// 最大长度为AuthorConsts.MaxNameLength
        /// </summary>
        /// <param name="name"></param>
        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AuthorConsts.MaxNameLength);
        }
    }
}
