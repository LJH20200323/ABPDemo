using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task CreateAsync(UserCreationDto input);
        Task UpdateAsync(UserUpdateDto input);
        Task ChangePasswordAsync(UserChangePasswordDto input);
    }
}
