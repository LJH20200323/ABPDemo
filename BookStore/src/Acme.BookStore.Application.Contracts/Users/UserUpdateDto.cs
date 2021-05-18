using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Users
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
