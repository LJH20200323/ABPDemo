using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Issues
{
    public interface IUserIssueService
    {
        Task<int> GetOpenIssueCountAsync(Guid id);
    }
}
