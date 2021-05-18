using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.NewIssues
{
    public class NewIssue: AggregateRoot<Guid>
    {
        public Guid RepositoryId { get; private set; }
        public string Title { get; private set; }
        public string Text { get; set; }
        public Guid? AssignedUserId { get; internal set; }

        public NewIssue(Guid id, Guid repositoryId, string title, string text = null) : base(id)
        {
            RepositoryId = repositoryId;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Text = text;
        }

        private NewIssue() { }

        public void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        }

    }
}
