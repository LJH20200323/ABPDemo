using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Issues
{
    public class IssueAppService : ApplicationService, IIssueAppService
    {
        //private readonly IIssueRepository _issueRepository;
        private readonly IRepository<Issue,Guid> _issueRepository;
        public IssueAppService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task DoItAsync()
        {
            var issues = await AsyncExecuter.ToListAsync(_issueRepository.Where(new InActiveIssueSpecification()));
        }
    }
}
