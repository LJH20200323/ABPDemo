using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Issues
{
    public class Issue : AggregateRoot<Guid>
    {
        public Guid RepositoryId { get; private set; }

        public string Title { get; private set; }

        public string Text { get; private set; }

        public Guid? AssignedUserId { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsLocked { get; private set; }

        public IssueCloseReason? CloseReason { get; private set; } 

        public ICollection<IssueLabel> Labels { get; private set; }

        public Issue(
            Guid id,
            Guid repositoryId,
            string title,
            string text = null,
            Guid? assignedUserId = null
            ) : base(id)
        {
            RepositoryId = repositoryId;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));

            Text = text;
            AssignedUserId = assignedUserId;

            Labels = new Collection<IssueLabel>();
        }

        private Issue() {

        }

        public void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        }

        public void Close(IssueCloseReason reason)
        {
            IsClosed = true;
            CloseReason = reason;
        }

        public void ReOpen()
        {
            if (IsLocked)
            {
                throw new IssueStateException(
                    "IssueTracking:CanNotOpenLockedIssue"
                );
            }
            IsClosed = false;
            CloseReason = null;
        }

        public void Lock()
        {
            if (!IsClosed)
            {
                throw new IssueStateException(
                    "Can not open a locked issue! Unlock it first."
                );
            }

            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }
    }
}
