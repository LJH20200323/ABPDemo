using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
