using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Users
{
    public class UserCreationDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
