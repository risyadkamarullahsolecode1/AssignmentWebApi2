﻿using AssignmentWebApi2.Interfaces;
using AssignmentWebApi2.Models;

namespace AssignmentWebApi2.Services
{
    public class BookServices:IBookServices
    {
        private readonly List<Book> _books = new();

        // Get All
        public List<Book> GetAllBooks()
        {
            return _books;
        }

        // GET Book By Id
        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        //Add books
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // Update
        public void UpdateBook(int id, Book updatedBook)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.PublicationYear = updatedBook.PublicationYear;
                book.ISBN = updatedBook.ISBN;
            }
        }

        // Delete
        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
