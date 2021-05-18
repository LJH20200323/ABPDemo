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
            var newIssue = await _newIssueManager.CreateAsync(GuidGenerator.Create(),input.Title,input.Text);
            if (input.AssignedUserId.HasValue)
            {
                var user = await _userRepository.GetAsync(input.AssignedUserId.Value);
                await _newIssueManager.AssignToAsync(newIssue, user);
            }
            await _newIssueRepository.InsertAsync(newIssue);
            return ObjectMapper.Map<NewIssue, NewIssueDto>(newIssue);
        }

        public async Task<NewIssueDto> UpdateAsync(Guid id, UpdateNewIssueDto input)
        {
            var newIssue = await _newIssueRepository.GetAsync(id);
            await _newIssueManager.ChangeTitleAsync(newIssue,input.Title);

            if (input.AssignedUserId.HasValue)
            {
                var user = await _userRepository.GetAsync(input.AssignedUserId.Value);
                await _newIssueManager.AssignToAsync(newIssue, user);
            }
            newIssue.Text = input.Text;
            await _newIssueRepository.UpdateAsync(newIssue);
            return ObjectMapper.Map<NewIssue,NewIssueDto>(newIssue);
        }
    }
}
