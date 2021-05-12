using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Districts
{
    public class District:Entity
    {
        public Guid CId { get; set; }

        public string Name { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { CId, Name };
        }
    }
}
