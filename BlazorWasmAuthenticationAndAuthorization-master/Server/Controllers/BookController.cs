using BlazorWasmAuthenticationAndAuthorization.Server.Interfaces;
using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookService;

        public BookController(IBook bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await Task.FromResult(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Book book = _bookService.GetBookData(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Book book)
        {
            _bookService.AddBook(book);
        }

        [HttpPut]
        public void Put(Book book)
        {
            _bookService.UpdateBook(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
        [HttpGet]
        [Route("string")]
        public void datastring()
        {
             _bookService.datastring();
        }

        [HttpGet]
        [Route("GetCategoryList")]
        public async Task<IEnumerable<Category>> CategoryList()
        {
            return await Task.FromResult(_bookService.GetCategory());
        }
    }

}
