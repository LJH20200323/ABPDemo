using Acme.BookStore.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.NewIssues
{
    public class NewIssueAppService : ApplicationService, INewIssueAppService
    {
        private readonly NewIssueManager _newIssueManager;
        private readonly IRepository<NewIssue, Guid> _newIssueRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public NewIssueAppService(
            NewIssueManager newIssueManager,
            IRepository<NewIssue, Guid> newIssueRepository,
            IRepository<AppUser, Guid> userRepository)
        {
            _newIssueManager = newIssueManager;
            _newIssueRepository = newIssueRepository;
            _userRepository = userRepository;
        }

        public async Task<NewIssueDto> CreateAsync(NewIssueCreationDto input)
        {
            var newIssue = new NewIssue(
            GuidGenerator.Create(),
            input.RepositoryId,
            input.Title,
            input.Text);
            if (input.AssignedUserId.HasValue)
            {
                var user = await _userRepository.GetAsync(input.AssignedUserId.Value);
                await _newIssueManager.AssignToAsync(newIssue, user);
            }
            await _newIssueRepository.InsertAsync(newIssue);
            return ObjectMapper.Map<NewIssue, NewIssueDto>(newIssue);
        }
    }
}
