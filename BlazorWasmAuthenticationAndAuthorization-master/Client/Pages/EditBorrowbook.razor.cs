using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorWasmAuthenticationAndAuthorization.Client.Pages
{
    public class EditBorrowbookBase: ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int borrowbookID { get; set; }

        protected string Title = "Add";
        public BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks borrowbook = new();
        protected List<Book> bookList = new();

        protected override async Task OnInitializedAsync()
        {
            await GetBook();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (borrowbookID != 0)
            {
                Title = "Edit";
                borrowbook = await Http.GetFromJsonAsync<BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks>("api/Borrowbooks/" + borrowbookID);
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
                await Http.PutAsJsonAsync("api/Borrowbooks", borrowbook);
            }
            else
            {
                await Http.PostAsJsonAsync("api/Borrowbooks", borrowbook);
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchBorrowbook");
        }
    }
}
