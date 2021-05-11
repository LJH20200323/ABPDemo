using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Orders
{
    /// <summary>
    /// 聚合根实体
    /// </summary>
    public class Order: AggregateRoot<Guid>
    {
        public Order()
        {

        }

        public virtual string ReferenceNo { get; protected set; }

        public virtual int TotalItemCount { get; protected set; }

        public virtual DateTime CreationTime { get; protected set; }

        public virtual List<OrderLine> OrderLines { get; protected set; }

        public Order(Guid id, string referenceNo)
        {
            Check.NotNull(referenceNo, nameof(referenceNo));

            Id = id;
            ReferenceNo = referenceNo;

            OrderLines = new List<OrderLine>();
        }

        public void AddProduct(Guid productId, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException(
                    "You can not add zero or negative count of products!",
                    nameof(count)
                );
            }

            var existingLine = OrderLines.FirstOrDefault(ol => ol.ProductId == productId);

            if (existingLine == null)
            {
                OrderLines.Add(new OrderLine(this.Id, productId, count));
            }
            else
            {
                existingLine.ChangeCount(existingLine.Count + count);
            }

            TotalItemCount += count;
        }
    }
}
