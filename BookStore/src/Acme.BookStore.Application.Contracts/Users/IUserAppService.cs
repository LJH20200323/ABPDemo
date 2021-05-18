using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserDto> Get(Guid id);
        Task<List<UserDto>> GetList();
        Task<UserDto> Create(UserCreationDto input);
        Task<UserDto> Update(UserUpdateDto input);
    }
}
