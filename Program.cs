using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConsoleApplication7
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using System;
//            using System.Collections.Generic;
//            using System.Linq;
//            using System.Text;
//            using System.Threading.Tasks;

namespace LibraryTerminal

{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Admin admin = new Admin();
            User user = new User();

            Admin.library = library;
            User.library = library;

            string userResponce = "";

            Console.WriteLine("Welome to Grand Circus Online Library!");

            Console.Write("Please enter your name:\t");
            string name = Console.ReadLine();
            int Index = 0;
            Console.WriteLine("Please Enter Your Account Number");
            int accountNumber = int.Parse(Console.ReadLine());

        start:
            do
            {
                Console.WriteLine("Do you want to check out all the books in our Library? (yes/no)");
                userResponce = Console.ReadLine().ToLower();
                if (userResponce == "yes")
                {
                    library.displayBooks();
                    Console.WriteLine("Please enter a book name to add to the cart");
                    bool selectedBook = int.TryParse(Console.ReadLine(), out Index);
                    List<Books> CheckOutList = new List<Books>();
                    foreach (Books book in Admin.listOfBooks)
                    {
                        if (book.Index == Index)
                        {
                            {
                                CheckOutList.Add(book);
                                Console.WriteLine("Book {0} added to the cart", book.title);
                                book.copies--;
                            }
                        }

                    }

                    Console.WriteLine("Seach another book? (y/n)");
                    userResponce = Console.ReadLine();
                    if (userResponce == "y")
                        goto start;

                }
                else
                {
                    Console.WriteLine("How would you like to search the book?");
                    Console.WriteLine("By Category (1) or by Author(2) or by Title (3)");

                    string seachCriteria = Console.ReadLine().ToUpper();
                    switch (seachCriteria)
                    {
                        case "1":
                        case "CATEGORY":
                            Console.WriteLine("The available categories are:");
                            library.displayCategories();

                            Console.WriteLine("Please select One Category");

                            string selectedCategory = Console.ReadLine();

                            Console.WriteLine("The books in {0} Category are: ", selectedCategory);

                            foreach (Books book in Admin.listOfBooks)
                            {
                                if (book.category == selectedCategory)

                                    Console.WriteLine("Book Title:\t" + book.title + "\t\t" + book.availability);

                            }
                            Console.WriteLine("Choose a book to add to cart");


                            Console.WriteLine("Would you like to search another book?");
                            string searchAnotherBook = Console.ReadLine().ToLower();
                            if (searchAnotherBook == "yes")
                                goto start;
                            else
                                Console.WriteLine("Thank You");
                            //goto checkout
                            break;

                        case "2":
                        case "AUTHOR":
                            //AuthorName:
                            Console.WriteLine("Would you like to check the available authors in our Library? (y/n)");
                            string yes = Console.ReadLine();
                            if (yes == "y")
                            {
                                Console.WriteLine("The available authorList:");
                                library.displayAuthorList();
                            }
                            Console.WriteLine("Please enter the Author Name");
                            string selectedAuthorName = Console.ReadLine();

                            foreach (Books book in Admin.listOfBooks)
                            {

                                if (book.author == selectedAuthorName)

                                    Console.WriteLine("Book Title \t" + book.title + "\t" + book.availability);

                            }
                            Console.WriteLine("Would You like to check out another book? (y/n)");
                    }
                }
            }
            while (true);
        }
    }
}