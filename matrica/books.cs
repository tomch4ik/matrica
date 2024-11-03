using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Matrica
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
        public override string ToString()
        {
            return $"'{Title}' Автор: {Author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Book otherBook)
            {
                return Title == otherBook.Title && Author == otherBook.Author;
            }
            return false;
        }
    }
    internal class BookList
    {
        private List<Book> books = new List<Book>();
        public void AddNewBook(Book book)
        {
            bool bookExists = false;
            foreach (Book searchBook in books)
            {
                if (searchBook.Equals(book))
                {
                    bookExists = true;
                    break;
                }
            }
            if (!bookExists)
            {
                books.Add(book);
                Console.WriteLine($"Книга добавлена: {book}");
            }
            else
            {
                Console.WriteLine($"Книга уже в списке: {book}");
            }
        }
        public void DeleteBook(Book book)
        {
            bool bookExists = false;
            foreach (Book existingBook in books)
            {
                if (existingBook.Equals(book))
                {
                    bookExists = true;
                    books.Remove(existingBook);
                    Console.WriteLine($"Книга удалена: {book}");
                    break;
                }
            }
            if (!bookExists)
            {
                Console.WriteLine($"Книга не найдена в списке: {book}");
            }
        }
        public bool ContainsBook(Book book)
        {
            foreach (Book existingBook in books)
            {
                if (existingBook.Equals(book))
                {
                    return true;
                }
            }
            return false;
        }
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Count)
                {
                    throw new IndexOutOfRangeException("Неверный индекс книги.");
                }
                return books[index];
            }
        }
        public int Count
        {
            get { return books.Count; }
        }

        public void PrintAllBooks()
        {
            Console.WriteLine("Список книг:");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        public override int GetHashCode()
        {
            return books.GetHashCode();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList BookList = new BookList();
            Book book1 = new Book("1984", "Джордж Оруэлл");
            Book book2 = new Book("Приключения Тома Сойера", "Марк Твен");
            Book book3 = new Book("Морской Волк", "Джек Лондон");
            BookList.AddNewBook(book1);
            BookList.AddNewBook(book2);
            BookList.AddNewBook(book3);
            if (BookList.ContainsBook(book1))
            {
                Console.WriteLine("Книга есть в списке.");
            }
            else
            {
                Console.WriteLine("Книги не найдено.");
            }
            BookList.DeleteBook(book2);
            BookList.PrintAllBooks();
            Console.WriteLine($"Первая книга по списку: {BookList[0]}");
        }
    }
}

