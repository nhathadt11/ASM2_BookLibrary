using MyBookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_BookLibrary
{
    class Program
    {
        static MyBookLibrary.MyBookLibrary bookLibrary = new MyBookLibrary.MyBookLibrary();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--- My Book Library ---");
                int userChoice = Menu();
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("-- Please enter book details --");
                        int id;
                        Book book;
                        if (bookLibrary.FindBook((id = GetBookID())) == null)
                        {
                            book = MoreBookDetailsFor(id);
                            if (bookLibrary.Add(book))
                            {
                                Console.WriteLine("Successfully added " + id);
                            }
                            else
                            {
                                Console.WriteLine("Failed to add " + id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book " + id + " is already existing!");
                        }
                        break;
                    case 2:
                        if (bookLibrary.FindBook((id = GetBookID())) != null)
                        {
                            book = MoreBookDetailsFor(id);
                            if (bookLibrary.Update(book))
                            {
                                Console.WriteLine("Successfully updated " + id);
                            }
                            else
                            {
                                Console.WriteLine("Failed to update " + id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book " + id + " not found!");
                        }
                        break;
                    case 3:
                        if (bookLibrary.FindBook((id = GetBookID())) != null)
                        {
                            if (bookLibrary.Remove(id))
                            {
                                Console.WriteLine("Successfully removed " + id);
                            }
                            else
                            {
                                Console.WriteLine("Failed to remove " + id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book " + id + " not found!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("--- Book List ---");
                        if (bookLibrary.Data.Count != 0)
                        {
                            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-10}", "ID", "Title", "Publisher", "Price");
                            bookLibrary.Data.ForEach(s => Console.WriteLine(s));
                        }
                        else
                        {
                            Console.WriteLine("Storage is empty!");
                        }
                        break;
                    default:
                        Console.WriteLine("See you next time!");
                        return;
                }
            }
        }
        static int Menu()
        {
            Console.WriteLine("1. Add new book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Remove a book");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. Quit");
            while (true)
            {
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 6) return choice;
            }
        }
        static int GetBookID()
        {
            Console.Write("ID: ");
            int id;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out id) && id > 0) return id;
                else Console.WriteLine("ID must be an positive integer");
            }
        }
        static Book MoreBookDetailsFor(int id)
        {
            Console.Write("Title: ");
            string title;
            while ((title = Console.ReadLine()) == string.Empty)
            {
                Console.WriteLine("Cannot leave title empty!");
            }
            Console.Write("Publisher: ");
            string publisher;
            while ((publisher = Console.ReadLine()) == string.Empty)
            {
                Console.WriteLine("Cannot leave publisher empty!");
            }
            Console.Write("Price: ");
            float price;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out price) && price > 0) break;
                else Console.WriteLine("Price must be a float greater than 0!");
            }
            return new Book
            {
                ID = id,
                Title = title,
                Publisher = publisher,
                Price = price
            };
        }
    }
}
