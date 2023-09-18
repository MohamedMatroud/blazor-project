using BlazorWasmAuthenticationAndAuthorization.Server.Interfaces;
using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmAuthenticationAndAuthorization.Server.DataAccess
{
    public class BookDataAccessLayer : IBook
    {
      public string Result = "86555vghg";

        readonly EmployeeDBContext _dbContext = new();

        public BookDataAccessLayer(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all Books details   
        public List<Book> GetAllBooks()
        {
            try
            {
                var result = _dbContext.Books.ToList()
                   .Select(x =>
                   {

                       return new Models.Book
                       {
                           BookID = x.BookID,
                           BookName = x.BookName ?? "",
                           Author = x.Author,
                           Category = x.Category ?? "",
                           BookDescribation = x.BookDescribation ?? "",

                       };
                   }).ToList();
                return result;

                //return _dbContext.Books.ToList();
            }
            catch
            {
                throw;
            }
        }


        //To Add new employee Book     
        public void AddBook(Book book)
        {
            try
            {
                var exists = _dbContext.Books.FirstOrDefault(x => x.BookName == book.BookName);
                if (exists != null)
                {

                    var status = "Book Name Aleardy Add";

                }
                else
                {
                    var cat = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == book.CategoryID);
                    book.Category = cat.CategoryName;
                    book.Active = false;
                    _dbContext.Books.Add(book);
                    _dbContext.SaveChanges();
                }

            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Book    
        public void UpdateBook(Book book)
        {
            try
            {
                _dbContext.Entry(book).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Book    
        public Book GetBookData(int id)
        {
            try
            {
                Book? book = _dbContext.Books.Find(id);

                if (book != null)
                {
                    return book;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Book    
        public void DeleteBook(int id)
        {
            try
            {
                Book? book = _dbContext.Books.Find(id);
                var borrowbok = _dbContext.Borrowbooks.FirstOrDefault(x=> x.BookID == id);
                Result = "ddddddd";

                if (book != null)
                {
                    Result = "ddddddd";


                    if (borrowbok != null)
                    {
                        Result = "ddddddd";
                    }
                    else
                    {
                        _dbContext.Books.Remove(book);
                        _dbContext.SaveChanges();
                    }
                   
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        public string datastring()
        {

            return Result;
        }


        // To get the list of Category
        public List<Category> GetCategory()
        {
            try
            {
                return _dbContext.Categories.ToList();
            }
            catch
            {
                throw;
            }
        }

       

    }

}
