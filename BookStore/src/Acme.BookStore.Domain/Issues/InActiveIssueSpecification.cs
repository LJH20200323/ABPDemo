using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Issues
{
    public class InActiveIssueSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression()
        {
            var daysAgo30 = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            return i =>!i.IsClosed &&i.AssignedUserId == null &&i.CreationTime < daysAgo30 &&(i.LastCommentTime == null || i.LastCommentTime < daysAgo30);
        }
    }
}
