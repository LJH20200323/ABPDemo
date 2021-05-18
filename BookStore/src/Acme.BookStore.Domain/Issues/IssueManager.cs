using Acme.BookStore.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Issues
{
    public class IssueManager : DomainService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueManager(IRepository<Issue, Guid> issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task AssignToAsync(Issue issue, AppUser user)
        {
            var openIssueCount = await _issueRepository.CountAsync(
                i => i.AssignedUserId == user.Id && !i.IsClosed
            );

            if (openIssueCount >= 3)
            {
                throw new BusinessException("IssueTracking:ConcurrentOpenIssueLimit");
            }
            issue.AssignedUserId = user.Id;
        }
    }

}
