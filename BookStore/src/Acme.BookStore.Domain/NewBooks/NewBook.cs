using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.NewBooks
{
    public class NewBook:Entity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 带参构造函数
        /// 注:不要使用Guid.NewGuid()创建实体,使用GuidGenerator.Create()可以产生连续的GUID
        /// 对于数据库聚集索引非常重要
        /// </summary>
        /// <param name="id"></param>
        public NewBook(Guid id):base(id)
        {

        }

        /// <summary>
        /// 带参构造函数创建实体,private/protected构造函数
        /// 读取实体时(反序列化时)将使用到
        /// </summary>
        protected NewBook()
        {

        }
    }
}
