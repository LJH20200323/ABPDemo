using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Issues
{
    public class EfCoreIssueRepository : EfCoreRepository<BookStoreDbContext, Issue, Guid>, IIssueRepository
    {
        public EfCoreIssueRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Issue>> GetInActiveIssuesAsync()
        {
            var days = DateTime.Now.Subtract(TimeSpan.FromDays(15));
            return await DbSet.Where(i =>!i.IsClosed &&i.AssignedUserId == null &&i.CreationTime < days && (i.LastCommentTime == null || i.LastCommentTime < days)).ToListAsync();
        }
    }
}
