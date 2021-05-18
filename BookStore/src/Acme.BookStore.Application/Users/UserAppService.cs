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

        public Task<UserDto> Create(UserCreationDto input)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Update(UserUpdateDto input)
        {
            throw new NotImplementedException();
        }
    }
}
