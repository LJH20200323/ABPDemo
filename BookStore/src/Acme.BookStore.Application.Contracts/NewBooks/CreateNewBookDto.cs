using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.NewBooks
{
    public class CreateNewBookDto
    {
        [Required]
        [StringLength(NewBookConsts.MaxNameLength)]
        public string Name { get; set; }

        public BookType Type { get; set; }

        public float? Price { get; set; }
    }
}
