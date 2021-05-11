using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Acme.BookStore.Authors
{
    /// <summary>
    /// 作者数据仓库
    /// </summary>
    public class EfCoreAuthorRepository : EfCoreRepository<BookStoreDbContext, Author, Guid>, IAuthorRepository
    {
        public EfCoreAuthorRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) :base(dbContextProvider)
        {

        }

        /// <summary>
        /// 根据查询条件(name)返回Author
        /// 精准查询
        /// </summary>
        /// <param name="name">作者名称</param>
        /// <returns>作者表实体</returns>
        public async Task<Author> FindByNameAsync(string name)
        {
            var dbset = await GetDbSetAsync();
            return await dbset.FirstOrDefaultAsync(x=>x.Name==name);
        }

        /// <summary>
        /// 根据查询条件查询(模糊查询)作者表数据集
        /// </summary>
        /// <param name="skipCount">起始数</param>
        /// <param name="maxResultCount">页数</param>
        /// <param name="sorting">排序字段字符串</param>
        /// <param name="filter">查询条件(模糊查询)</param>
        /// <returns>作者表数据集</returns>
        public async Task<List<Author>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbset = await GetDbSetAsync();
            return await dbset.WhereIf(!filter.IsNullOrWhiteSpace(), x => x.Name.Contains(filter))
                .OrderBy(sorting)//排序
                .Skip(skipCount).Take(maxResultCount)//分页
                .ToListAsync();
        }
    }
}
