using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorWasmAuthenticationAndAuthorization.Client.Pages
{
    public class ReciveBorrowbookBase : ComponentBase
    {
      
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int borrowbookID { get; set; }


        protected string Title = "Add";
        public BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks borrowbook = new();
        public Book book = new();

        protected List<Book> bookList = new();

        protected override async Task OnInitializedAsync()
        {
            await GetBook();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (borrowbookID != 0)
            {
                
                Title = "Recive";
                borrowbook = await Http.GetFromJsonAsync<BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks>("api/Borrowbooks/" + borrowbookID);
                DateTime? today = DateTime.Now;
                DateTime? currentTime = DateTime.Now;
                DateTime date = Convert.ToDateTime(borrowbook.Returndate);

                int? d3 = (int?)(currentTime - date)?.TotalDays;
                if (d3 > 0)
                {
                    d3 = d3;
                }
                else
                {
                    d3 = 0;
                }
                book = await Http.GetFromJsonAsync<Book>("api/Book/" + borrowbook.BookID);
                borrowbook.Delaypenalty = d3 * 10;
                borrowbook.BookName = book.BookName;
            }
        }

        protected async Task GetBook()
        {
            bookList = await Http.GetFromJsonAsync<List<Book>>("api/Borrowbooks/GetBookListUpdate");
        }

        protected async Task SaveBorrowbooks()
        {
            if (borrowbook.BorrowbookID != 0)
            {
                await Http.PutAsJsonAsync("api/Borrowbooks/Recive", borrowbook);
            }
          
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchBorrowbook");
        }

    }
}
