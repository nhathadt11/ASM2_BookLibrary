using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
    public class MyBookLibrary
    {
        private List<Book> _data;

        public List<Book> Data { get; }

        public MyBookLibrary()
        {
            Data = new List<Book>();
        }
        public bool Add(Book book)
        {
            Book foundBook = FindBook(book);
            if( foundBook == null)
            {
                Data.Add(book);
            }
            return foundBook == null;
        }
        public bool Remove(int id)
        {
            Book foundBook = FindBook(id);
            if (foundBook != null)
            {
                Data.Remove(foundBook);
            }
            return foundBook != null;
        }
        public bool Update(Book book)
        {
            Book foundBook = FindBook(book);
            if (foundBook != null)
            {
                foundBook.Title = book.Title;
                foundBook.Publisher = book.Publisher;
                foundBook.Price = book.Price;
            }
            return foundBook != null;
        }
        public Book FindBook(int id)
        {
            return Data.Find(b => b.ID == id);
        }
        public Book FindBook(Book book)
        {
            return Data.Find(b => b.ID == book.ID);
        }
    }
}
