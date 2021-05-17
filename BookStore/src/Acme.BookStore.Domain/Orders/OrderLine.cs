using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Orders
{
    public class OrderLine : Entity
    {
        public virtual Guid OrderId { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual int Count { get; protected set; }

        public OrderLine()
        {

        }

        internal OrderLine(Guid orderId, Guid productId, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

        internal void ChangeCount(int newCount)
        {
            Count = newCount;
        }

        public override object[] GetKeys()
        {
            return new object[] { OrderId, ProductId };
        }
    }
}
