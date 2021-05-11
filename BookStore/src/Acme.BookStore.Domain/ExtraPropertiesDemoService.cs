using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Acme.BookStore
{
    public class ExtraPropertiesDemoService: ITransientDependency
    {
        private readonly IIdentityUserRepository _identityUserRepository;

        public ExtraPropertiesDemoService(IIdentityUserRepository identityUserRepository)
        {
            _identityUserRepository = identityUserRepository;
        }

        public async Task SetTitle(Guid userId,string title)
        {
            var user = await _identityUserRepository.GetAsync(userId);
            user.SetProperty("Title",title);
            await _identityUserRepository.UpdateAsync(user);
        }

        public async Task<string> GetTitle(Guid userId)
        {
            var user = await _identityUserRepository.GetAsync(userId);
            return user.GetProperty<string>("Title");
        }
    }
}
