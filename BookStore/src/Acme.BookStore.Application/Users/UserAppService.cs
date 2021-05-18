using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Users
{
    public class UserAppService : IUserAppService, IApplicationService
    {
        private readonly IRepository<AppUser, Guid> _userRepository;
        public UserAppService(IRepository<AppUser, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ChangePasswordAsync(UserChangePasswordDto input)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(UserCreationDto input)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserUpdateDto input)
        {
            throw new NotImplementedException();
        }
    }
}
