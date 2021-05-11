using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.BookStore.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        /// <summary>
        /// 异常提示信息
        /// </summary>
        /// <param name="name"></param>
        public AuthorAlreadyExistsException(string name)
            : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
