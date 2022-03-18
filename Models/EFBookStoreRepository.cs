using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private BookstoreContext context {get; set; }

        public EFBookStoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Books> Books => context.Books;

        public void SaveBook(Books b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Books b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Books b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
