using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Users
{
    public class UserChangePasswordDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}
