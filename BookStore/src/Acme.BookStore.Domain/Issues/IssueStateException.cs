using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.BookStore.Issues
{
    public class IssueStateException : BusinessException
    {
        public IssueStateException(string message)
            : base(message)
        {

        }
    }
}
