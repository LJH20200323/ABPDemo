using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.NewBooks
{
    public class NewBookDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public BookType Type { get; set; }

        public float? Price { get; set; }
    }
}
