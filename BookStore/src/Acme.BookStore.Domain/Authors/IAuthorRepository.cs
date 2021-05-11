using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Authors
{
    /// <summary>
    /// 作者实体数据仓库
    /// </summary>
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
        /// <summary>
        /// 根据查询条件(name)返回Author
        /// 精准查询
        /// </summary>
        /// <param name="name">作者名称</param>
        /// <returns>作者表实体</returns>
        Task<Author> FindByNameAsync(string name);

        /// <summary>
        /// 根据查询条件查询(模糊查询)作者表数据集
        /// </summary>
        /// <param name="skipCount">起始数</param>
        /// <param name="maxResultCount">页数</param>
        /// <param name="sorting">排序字段字符串</param>
        /// <param name="filter">查询条件(模糊查询)</param>
        /// <returns></returns>
        Task<List<Author>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null);
    }
}
