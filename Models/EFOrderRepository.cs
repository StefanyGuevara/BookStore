using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;
        public EFOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Orders => context.orders.Include(x => x.Lines).ThenInclude(x => x.Books);


        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Books));

            if( order.OrderId == 0)
            {
                context.orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
