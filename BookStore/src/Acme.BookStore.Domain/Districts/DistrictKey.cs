using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Districts
{
    public class DistrictKey
    {
        public Guid CityId { get; set; }

        public string Name { get; set; }
    }
}
