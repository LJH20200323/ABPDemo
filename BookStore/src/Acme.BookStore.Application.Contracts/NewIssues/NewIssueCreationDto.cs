using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.NewIssues
{
    public class NewIssueCreationDto
    {
        public Guid RepositoryId { get;  set; }
        public string Title { get;  set; }
        public string Text { get; set; }
        public Guid? AssignedUserId { get; internal set; }
    }
}
