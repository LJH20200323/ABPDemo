using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Persons
{
    public class PersonDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
