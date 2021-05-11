using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.NewBooks
{
    public class NewBook: AggregateRoot<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public BookType Type { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float? Price { get; set; }

        /// <summary>
        /// 带参构造函数
        /// 注:不要使用Guid.NewGuid()创建实体,使用GuidGenerator.Create()可以产生连续的GUID
        /// 对于数据库聚集索引非常重要
        /// </summary>
        /// <param name="id"></param>
        public NewBook(Guid id,[NotNull]string name,BookType type,float? price=-0):base(id)
        {
            Id = id;
            Name = CheckName(name);
            Type = type;
            Price = price;
        }

        /// <summary>
        /// 带参构造函数创建实体,private/protected构造函数
        /// 读取实体时(反序列化时)将使用到
        /// </summary>
        protected NewBook()
        {

        }

        public virtual void ChangeName([NotNull]string name)
        {
            Name = CheckName(name);
        }


        private static string CheckName(string name)
        {
            if (string .IsNullOrWhiteSpace(name))
                throw new ArgumentException($"name can not be empty or white space!");
            if (name.Length > MaxNameLength)
                throw new ArgumentException($"name can not be longer than {MaxNameLength} chars!");
            return name;
        }
    }
}
