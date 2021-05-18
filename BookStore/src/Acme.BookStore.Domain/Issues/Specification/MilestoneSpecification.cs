using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Issues.Specification
{
    public class MilestoneSpecification : Specification<Issue>
    {
        public Guid MilestoneId { get; }

        public MilestoneSpecification(Guid milestoneId)
        {
            MilestoneId = milestoneId;
        }

        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return i => i.MilestoneId == MilestoneId;
        }
    }
}
