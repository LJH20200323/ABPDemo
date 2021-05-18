using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Issues
{
    public class EfCoreIssueRepository : EfCoreRepository<BookStoreDbContext, Issue, Guid>, IIssueRepository
    {
        public EfCoreIssueRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Issue>> GetIssuesAsync(ISpecification<Issue> spec)
        {
            return await DbSet.Where(spec.ToExpression()).ToListAsync();
        }
    }
}
