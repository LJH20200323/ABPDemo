using Acme.BookStore.Issues.Specification;
using Acme.BookStore.Users;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Issues
{
    public class IssueAppService : ApplicationService, IIssueAppService
    {
        //private readonly IIssueRepository _issueRepository;
        private readonly IRepository<Issue,Guid> _issueRepository;

        private readonly IssueManager _issueManager;

        private readonly IRepository<AppUser, Guid> _userRepostitory;

        public IssueAppService(IRepository<Issue, Guid> issueRepository, IRepository<AppUser, Guid> userRepostitory, IssueManager issueManager)
        {
            _issueRepository = issueRepository;
            _userRepostitory = userRepostitory;
            _issueManager = issueManager;
        }

        public async Task DoItAsync(Guid milestoneId)
        {
            var issues = await AsyncExecuter.ToListAsync(
                _issueRepository.Where(new InActiveIssueSpecification()
                .And(new MilestoneSpecification(milestoneId)).ToExpression()));
        }

        [Authorize]
        public async Task AssignAsync(IssueAssignDto input)
        {
            var issue = await _issueRepository.GetAsync(input.IssueId);
            var user = await _userRepostitory.GetAsync(input.UserId);
            await _issueManager.AssignToAsync(issue,user);
            await _issueRepository.UpdateAsync(issue);
        }
    }
}
