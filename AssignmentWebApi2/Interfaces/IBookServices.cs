using AssignmentWebApi2.Models;

namespace AssignmentWebApi2.Interfaces
{
    public interface IBookServices
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(int id, Book updatedBook);
        void DeleteBook(int id);
    }
}
