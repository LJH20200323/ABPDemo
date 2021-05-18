using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Issues
{
    public interface IIssueAppService: IApplicationService
    {
        Task DoItAsync(Guid milestoneId);
    }
}
