using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.UserRoles
{
    /// <summary>
    /// 复合主键实体
    /// </summary>
    public class UserRole : Entity
    {
        public Guid UserId { get; set; }

        public Guid Role { get; set; }

        public DateTime CreationTime { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { UserId, Role };
        }
    }
}
