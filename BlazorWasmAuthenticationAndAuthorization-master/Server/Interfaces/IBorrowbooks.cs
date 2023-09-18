using BlazorWasmAuthenticationAndAuthorization.Server.Models;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Interfaces
{
    public interface IBorrowbooks
    {
        public List<Shared.Refactored.Borrowbooks> GetAllBorrowbooks();
        public List<Shared.Refactored.Borrowbooks> GetAllBorrowbooksHistory();

        public List<Shared.Refactored.Borrowbooks> GetAllBorrowbooksRecive();


        public void AddBorrowbooks(Borrowbooks borrowbook);

        public void UpdateBorrowbooks(Borrowbooks borrowbook);
        public void UpdateBorrowbooksRecive(Borrowbooks borrowbook);

        public void UpdateBorrowbooksCancel(Borrowbooks borrowbook);
        public Borrowbooks GetBorrowbooksData(int id);



        public void DeleteBorrowbooks(int id);

        public List<Book> GetBook();
        public List<Book> GetBookUpdate();

    }
}
