using BlazorWasmAuthenticationAndAuthorization.Server.Interfaces;
using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmAuthenticationAndAuthorization.Server.DataAccess
{
    public class BorrowbooksDataAccessLayer : IBorrowbooks
    {
        readonly EmployeeDBContext _dbContext = new();

        public BorrowbooksDataAccessLayer(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all employees Borrowbooks   
        public List<Shared.Refactored.Borrowbooks> GetAllBorrowbooks()
        {
            try
            {
                var result = _dbContext.Borrowbooks.Where(x => x.ReturnStatus == false).ToList()
                   .Select(x =>
                   {
                       var book = _dbContext.Books.FirstOrDefault(a => a.BookID == x.BookID);
                       DateTime? today = DateTime.Now;
                       DateTime? currentTime = DateTime.Now;
                       DateTime date = Convert.ToDateTime(x.Returndate);

                       int? d3 = (int?)(currentTime - date)?.TotalDays;
                       string borrowDate = string.Empty;
                       string Returndate = string.Empty;
                       if (x.borrowDate == null)
                       {
                           borrowDate = string.Empty;
                       }
                       else
                       {
                           borrowDate = x.borrowDate.Value.ToShortDateString();
                       }

                       if (x.Returndate == null)
                       {
                           Returndate = string.Empty;
                       }
                       else
                       {
                           Returndate = x.Returndate.Value.ToShortDateString();
                       }
                       if (d3 > 0)
                       {
                           d3 = d3;
                       }
                       else
                       {
                           d3 = 0;
                       }


                       return new Shared.Refactored.Borrowbooks
                       {
                           BorrowbookID = x.BorrowbookID,
                           BookID = x.BookID,

                           BookName = book.BookName ?? "",
                           Borrowername = x.Borrowername ?? "",
                           NationalID = x.NationalID ?? "",
                           borrowDatestring = borrowDate,
                           Returndatestring = Returndate,
                           Price = x.Price ?? 0,
                           Delaypenalty = d3,
                           CancelReason = x.CancelReason,
                           DayNo = x.DayNo

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
        public List<Shared.Refactored.Borrowbooks> GetAllBorrowbooksHistory()
        {
            try
            {
                var result = _dbContext.Borrowbooks.Where(x => x.ReturnStatus == true).ToList()
                   .Select(x =>
                   {
                       var book = _dbContext.Books.FirstOrDefault(a => a.BookID == x.BookID);
                       DateTime? today = DateTime.Now;
                       DateTime? currentTime = DateTime.Now;
                       DateTime date = Convert.ToDateTime(x.Returndate);

                       int? d3 = (int?)(currentTime - date)?.TotalDays;
                       string borrowDate = string.Empty;
                       string Returndate = string.Empty;
                       string Recivedate = string.Empty;
                      
                       if (x.borrowDate == null)
                       {
                           borrowDate = string.Empty;
                       }
                       else
                       {
                           borrowDate = x.borrowDate.Value.ToShortDateString();
                       }

                       if (x.Returndate == null)
                       {
                           Returndate = string.Empty;
                       }
                       else
                       {
                           Returndate = x.Returndate.Value.ToShortDateString();
                       }

                       if (x.ReciveDate == null)
                       {
                           Recivedate = string.Empty;
                       }
                       else
                       {
                           Recivedate = x.ReciveDate.Value.ToShortDateString();
                       }

                       if (d3 > 0)
                       {
                           d3 = d3;
                       }
                       else
                       {
                           d3 = 0;
                       }


                       return new Shared.Refactored.Borrowbooks
                       {
                           BorrowbookID = x.BorrowbookID,
                           BookID = x.BookID,

                           BookName = book.BookName ?? "",
                           Borrowername = x.Borrowername ?? "",
                           NationalID = x.NationalID ?? "",
                           borrowDatestring = borrowDate,
                           Returndatestring = Returndate,
                           Price = x.Price ?? 0,
                           Delaypenalty = d3,
                           CancelReason = x.CancelReason,
                           DayNo = x.DayNo,
                           ReciveDateString = Recivedate,
                           Status = x.Status,

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

        public List<Shared.Refactored.Borrowbooks> GetAllBorrowbooksRecive()
        {
            try
            {
                var result = _dbContext.Borrowbooks.Where(x => x.ReturnStatus == false).ToList()
                   .Select(x =>
                   {
                       var book = _dbContext.Books.FirstOrDefault(a => a.BookID == x.BookID);
                       DateTime? today = DateTime.Now;
                       DateTime? currentTime = DateTime.Now;
                       DateTime date = Convert.ToDateTime(x.Returndate);

                       int? d3 = (int?)(currentTime - date)?.TotalDays;

                       //System.DateTime? diff1 = currentTime.Value.Subtract(date);
                       string borrowDate = string.Empty;
                       string Returndate = string.Empty;
                       if (x.borrowDate == null)
                       {
                           borrowDate = string.Empty;
                       }
                       else
                       {
                           borrowDate = x.borrowDate.Value.ToShortDateString();
                       }

                       if (x.Returndate == null)
                       {
                           Returndate = string.Empty;
                       }
                       else
                       {
                           Returndate = x.Returndate.Value.ToShortDateString();
                       }
                       if (d3 > 0)
                       {
                           d3 = d3;
                       }
                       else
                       {
                           d3 = 0;
                       }

                       return new Shared.Refactored.Borrowbooks
                       {
                           BorrowbookID = x.BorrowbookID,
                           BookID = x.BookID,

                           BookName = book.BookName ?? "",
                           Borrowername = x.Borrowername ?? "",
                           NationalID = x.NationalID ?? "",
                           borrowDatestring = borrowDate,
                           Returndatestring = Returndate,
                           Price = x.Price ?? 0,
                           Delaypenalty = d3

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


        public List<Shared.Refactored.Borrowbooks> Notfication()
        {
            try
            {
                var result = _dbContext.Borrowbooks.Where(x => x.ReturnStatus == false).ToList()
                   .Select(x =>
                   {
                       var book = _dbContext.Books.FirstOrDefault(a => a.BookID == x.BookID);

                       DateTime? today = DateTime.Now;
                       DateTime? currentTime = DateTime.Now;
                       DateTime date = Convert.ToDateTime(x.Returndate);
                       int count2 = 0;
                       int? d3 = (int?)(currentTime - date)?.TotalDays;
                       //var count = _dbContext.Borrowbooks.Count(a => ((int?)(currentTime - Convert.ToDateTime(a.Returndate))?.TotalDays) >=1);

                       string borrowDate = string.Empty;
                       string Returndate = string.Empty;
                       if (x.borrowDate == null)
                       {
                           borrowDate = string.Empty;
                       }
                       else
                       {
                           borrowDate = x.borrowDate.Value.ToShortDateString();
                       }

                       if (x.Returndate == null)
                       {
                           Returndate = string.Empty;
                       }
                       else
                       {
                           Returndate = x.Returndate.Value.ToShortDateString();
                       }
                       if (d3 > 0)
                       {
                           d3 = d3;
                       }
                       else
                       {
                           d3 = 0;
                       }


                       return new Shared.Refactored.Borrowbooks
                       {
                           BorrowbookID = x.BorrowbookID,
                           BookID = x.BookID,

                           BookName = book.BookName ?? "",
                           Borrowername = x.Borrowername ?? "",
                           NationalID = x.NationalID ?? "",
                           borrowDatestring = borrowDate,
                           Returndatestring = Returndate,
                           Price = x.Price ?? 0,
                           Delaypenalty = d3,
                           //Count = count

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


        //To Add new Borrowbooks record     
        public void AddBorrowbooks(Borrowbooks borrowbook)
        {

         
            try
            {
                var book = _dbContext.Books.FirstOrDefault(x => x.BookID == borrowbook.BookID && x.Active != true);


                borrowbook.ReturnStatus = false;
                borrowbook.Delaypenalty = 0;

                book.Active = true;
                borrowbook.borrowDate = DateTime.Now;

                DateTime? borrowDate = Convert.ToDateTime(borrowbook.borrowDate);
                DateTime Returndate = Convert.ToDateTime(borrowbook.Returndate);

                int? d3 = (int?)(Returndate - borrowDate)?.TotalDays;
                _dbContext.Borrowbooks.Add(borrowbook);
                borrowbook.DayNo = d3;

                _dbContext.SaveChanges();


            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Borrowbooks    
        public void UpdateBorrowbooks(Borrowbooks borrowbook)
        {
            try
            {
                _dbContext.Entry(borrowbook).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateBorrowbooksRecive(Borrowbooks borrowbook)
        {
            try
            {
                var book = _dbContext.Books.FirstOrDefault(x => x.BookID == borrowbook.BookID);
                book.Active = false;
                borrowbook.ReturnStatus = true;
                borrowbook.ReciveDate = DateTime.Now;
                borrowbook.Status = "Complete";

                _dbContext.Entry(borrowbook).State = EntityState.Modified;
                _dbContext.Entry(book).State = EntityState.Modified;

                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateBorrowbooksCancel(Borrowbooks borrowbook)
        {
            DateTime? now = DateTime.Now;
            DateTime borrowDatecheck = Convert.ToDateTime(borrowbook.borrowDate);

            int? check = (int?)(now - borrowDatecheck)?.TotalDays;
            try
            {
                if (check == 0)
                {
                    var book = _dbContext.Books.FirstOrDefault(x => x.BookID == borrowbook.BookID);
                    book.Active = false;
                    borrowbook.ReturnStatus = true;
                    borrowbook.ReciveDate = DateTime.Now;
                    borrowbook.Returndate = DateTime.Now;
                    borrowbook.Price = 0;
                    borrowbook.Delaypenalty = 0;

                    borrowbook.Status = "Cancel";
                    _dbContext.Entry(borrowbook).State = EntityState.Modified;
                    _dbContext.Entry(book).State = EntityState.Modified;

                    _dbContext.SaveChanges();
                }
               
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Borrowbooks    
        public Borrowbooks GetBorrowbooksData(int id)
        {
            try
            {
                Borrowbooks? book = _dbContext.Borrowbooks.Find(id);

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


        //To Delete the record of a particular Borrowbooks    
        public void DeleteBorrowbooks(int id)
        {
            try
            {
                Borrowbooks? book = _dbContext.Borrowbooks.Find(id);

                if (book != null)
                {
                    _dbContext.Borrowbooks.Remove(book);
                    _dbContext.SaveChanges();
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

        // To get the list of Book
        public List<Book> GetBook()
        {
            try
            {
                return _dbContext.Books.Where(x => x.Active == false).ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<Book> GetBookUpdate()
        {
            try
            {
                return _dbContext.Books.ToList();
            }
            catch
            {
                throw;
            }
        }
    }

}
