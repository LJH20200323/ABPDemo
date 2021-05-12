using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace Acme.BookStore.Districts
{
    public class DistrictAppService : AbstractKeyCrudAppService<District, DistrictDto, DistrictKey>
    {
        public DistrictAppService(IRepository<District> repository) :base(repository)
        {

        }

        protected async override Task DeleteByIdAsync(DistrictKey id)
        {
            await Repository.DeleteAsync(x => x.CityId == id.CityId && x.Name == id.Name);
        }

        protected async override Task<District> GetEntityByIdAsync(DistrictKey id)
        {
            return await AsyncExecuter.FirstOrDefaultAsync(Repository.Where(x=>x.CityId ==id.CityId && x.Name==id.Name));
        }
    }
}
