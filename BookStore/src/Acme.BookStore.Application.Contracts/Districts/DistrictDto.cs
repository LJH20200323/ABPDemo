using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Districts
{
    public class DistrictDto:EntityDto
    {
        public Guid CityId { get; set; }

        public string Name { get; set; }

    }
}
