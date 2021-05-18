using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Issues
{
    public class IssueAssignDto
    {
        public Guid IssueId { get; set; }

        public Guid UserId { get; set; }
    }
}
