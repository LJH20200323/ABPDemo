using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Products
{
    public class ProductDto:EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
