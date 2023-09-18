using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorWasmAuthenticationAndAuthorization.Client.Pages
{
    public class BorrowbookBase:ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        protected List<BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks> borrowbooksList = new();
        protected List<BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks> searchBookData = new();
        protected BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks borrowbooks = new();
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetBorrowbooks();
        }

        protected async Task GetBorrowbooks()
        {
            borrowbooksList = await Http.GetFromJsonAsync<List<BlazorWasmAuthenticationAndAuthorization.Shared.Refactored.Borrowbooks>>("api/Borrowbooks");
            searchBookData = borrowbooksList;
        }

        protected void FilterBook()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                borrowbooksList = searchBookData
                    .Where(x => x.Borrowername.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                borrowbooksList = searchBookData;
            }
        }

        protected void DeleteConfirm(int BorrowbooksID)
        {
            borrowbooks = borrowbooksList.FirstOrDefault(x => x.BorrowbookID == BorrowbooksID);
        }

        protected async Task DeleteBook(int BorrowbookskID)
        {
            await Http.DeleteAsync("api/Borrowbooks/" + BorrowbookskID);
            await GetBorrowbooks();
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            borrowbooksList = searchBookData;
        }
    }
}
