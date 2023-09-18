using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Reflection;

namespace BlazorWasmAuthenticationAndAuthorization.Client.Pages
{
    public class AddEditBookBase : ComponentBase
    {

        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int bookID { get; set; }

        protected string Title = "Add";
        public Book book = new();
        protected List<Category> categoryList = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCategory();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (bookID != 0)
            {
                Title = "Edit";
                book = await Http.GetFromJsonAsync<Book>("api/Book/" + bookID);
            }
        }

        protected async Task GetCategory()
        {
            categoryList = await Http.GetFromJsonAsync<List<Category>>("api/Book/GetCategoryList");
        }

        protected async Task SaveBook()
        {
            if (book.BookID != 0)
            {
                await Http.PutAsJsonAsync("api/Book", book);
            }
            else
            {
                await Http.PostAsJsonAsync("api/Book", book);
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchbook");
        }
    }
}
