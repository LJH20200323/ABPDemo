using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.NewIssues
{
    public interface INewIssueAppService: IApplicationService
    {
        Task<NewIssueDto> CreateAsync(NewIssueCreationDto input);

        Task<NewIssueDto> UpdateAsync(Guid id, UpdateNewIssueDto input)
    }
}
