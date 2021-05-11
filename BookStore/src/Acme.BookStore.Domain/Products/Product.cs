using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Products
{
    public class Product:Entity<Guid>
    {
        public string name { get; set; }
    }
}
