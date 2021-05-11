using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Persons
{
    public class CreatePersonDto: FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

    }
}
