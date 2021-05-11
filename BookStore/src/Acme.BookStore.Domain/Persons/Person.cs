using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Persons
{
    public class Person: Entity<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
