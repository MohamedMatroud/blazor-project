using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Interfaces
{
    public interface IBook
    {
        public List<Book> GetAllBooks();

        public void AddBook(Book book);

        public void UpdateBook(Book book);

        public Book GetBookData(int id);

        public void DeleteBook(int id);
        public String datastring();

        public List<Category> GetCategory();
    }
}
