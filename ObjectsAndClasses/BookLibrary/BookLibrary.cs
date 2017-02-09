namespace BookLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class BookLibrary
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var library = new Library()
            {
                Name = "MyLib",
                Books = new List<Book>()
            };

            AddBooks(n, library);

            var authors = new Dictionary<string, decimal>();

            foreach (var author in library.Books.Select(b => b.Author).Distinct())
            {
                var sumOfPrice = library.Books.Where(b => b.Author == author).Sum(b => b.Price);
               authors.Add(author, sumOfPrice);
            }

            foreach (var author in authors.OrderByDescending(k => k.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Value:f2}");
            }

        }

        private static void AddBooks(int n, Library library)
        {
            for (int i = 0; i < n; i++)     //Adding n-number of books to library.
            {
                var input = Console.ReadLine().Split();
                var title = input[0];
                var author = input[1];
                var publisher = input[2];
                var releaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var isbn = input[4];
                var price = decimal.Parse(input[5]);
                var book = new Book(title, author, publisher, releaseDate, isbn, price);
                library.Books.Add(book);
            }
        }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn, decimal price)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            ISBN = isbn;
            Price = price;
        }
    }
}