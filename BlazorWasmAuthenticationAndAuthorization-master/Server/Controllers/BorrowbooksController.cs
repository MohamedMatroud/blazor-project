using BlazorWasmAuthenticationAndAuthorization.Server.Interfaces;
using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowbooksController : ControllerBase
    {
        private readonly IBorrowbooks _borrowbookService;

        public BorrowbooksController(IBorrowbooks borrowbookService)
        {
            _borrowbookService = borrowbookService;
        }

        [HttpGet]
        public async Task<List<Shared.Refactored.Borrowbooks>> Get()
        {
            return await Task.FromResult(_borrowbookService.GetAllBorrowbooks());
        }
        [Route("History")]
        public async Task<List<Shared.Refactored.Borrowbooks>> GetHistory()
        {
            return await Task.FromResult(_borrowbookService.GetAllBorrowbooksHistory());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ////Borrowbooks book = _borrowbookService.GetBorrowbooksData(id);
            Borrowbooks book = _borrowbookService.GetBorrowbooksData(id);

            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        //[HttpGet]
        //[Route("ReciveData/" +"{id}")]

        //public IActionResult Getdata(int id)
        //{
        //    ////Borrowbooks book = _borrowbookService.GetBorrowbooksData(id);
        //    var book = _borrowbookService.GetBorrowbooksDataRecive(id);

        //    if (book != null)
        //    {
        //        return Ok(book);
        //    }
        //    return NotFound();
        //}


        [HttpPost]
        public void Post(Borrowbooks borrowbook)
        {
            _borrowbookService.AddBorrowbooks(borrowbook);
        }

        [HttpPut]
        public void Put(Borrowbooks borrowbook)
        {
            _borrowbookService.UpdateBorrowbooks(borrowbook);
        }
        [HttpPut]
        [Route("Recive")]
        public void PutRecive(Borrowbooks borrowbook)
        {
            _borrowbookService.UpdateBorrowbooksRecive(borrowbook);
        }
        [HttpPut]
        [Route("Cancel")]
        public void PutCancel(Borrowbooks borrowbook)
        {
            _borrowbookService.UpdateBorrowbooksCancel(borrowbook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _borrowbookService.DeleteBorrowbooks(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetBookList")]
        public async Task<IEnumerable<Book>> BookList()
        {
            return await Task.FromResult(_borrowbookService.GetBook());
        }
        [HttpGet]
        [Route("GetBookListUpdate")]
        public async Task<IEnumerable<Book>> BookListUpdate()
        {
            return await Task.FromResult(_borrowbookService.GetBookUpdate());
        }
    }

}
