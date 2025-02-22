using BooklyProject.Entities;
using System.Collections.Generic;

namespace BooklyProject.Controllers
{
    internal class BookViewModels
    {
        public List<Book> TopReviewedBooks { get; set; }
        public List<Book> OnSaleBooks { get; set; }
    }
}