using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Acme.BookStore
{
    public static class IdentityUserExtensions
    {
        private const string TitlePropertyName = "Title";

        public static void SetTitle(this IdentityUser user,string title)
        {
            user.SetProperty(TitlePropertyName, title);
        }

        public static string GetTitle(this IdentityUser user)
        {
            return user.GetProperty<string>(TitlePropertyName);
        }
    }
}
