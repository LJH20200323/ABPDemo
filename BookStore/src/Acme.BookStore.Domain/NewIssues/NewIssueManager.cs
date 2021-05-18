using Acme.BookStore.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.NewIssues
{
    public class NewIssueManager:DomainService
    {
        private readonly IRepository<NewIssue,Guid> _newIssueRepository;

        public NewIssueManager(IRepository<NewIssue, Guid> newIssueRepository)
        {
            _newIssueRepository = newIssueRepository;
        }

        public async  Task AssignToAsync(NewIssue newIssue, AppUser user)
        {
            var openIssueCount = await _newIssueRepository.CountAsync(
                i => i.AssignedUserId == user.Id);

            if (openIssueCount >= 3)
            {
                throw new BusinessException("IssueTracking:ConcurrentOpenIssueLimit");
            }
            newIssue.AssignedUserId = user.Id;
        }

        public async Task<NewIssue> CreateAsync(Guid repositoryId, string title, string text = null)
        {
            if (await _newIssueRepository.AnyAsync(i => i.Title == title))
                throw new BusinessException("IssueTracking:IssueWithSameTitleExists");
            return new NewIssue(
                GuidGenerator.Create(),
                repositoryId,
                title,
                text
            );
        }

        public async Task ChangeTitleAsync(NewIssue newIssue, string title)
        {
            if (newIssue.Title == title)
                return;
            if (await _newIssueRepository.AnyAsync(i => i.Title == title))
            {
                throw new BusinessException("IssueTracking:IssueWithSameTitleExists");
            }
            newIssue.SetTitle(title);

        }
    }
}
