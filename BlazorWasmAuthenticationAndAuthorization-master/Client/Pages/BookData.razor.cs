using BlazorWasmAuthenticationAndAuthorization.Client.Authentication;
using BlazorWasmAuthenticationAndAuthorization.Server.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http.Json;

namespace BlazorWasmAuthenticationAndAuthorization.Client.Pages
{
    public class BookDataBase : ComponentBase
    {
        [Inject]

        HttpClient Http { get; set; }

        protected List<Book> bookList = new();
        protected List<Book> searchBookData = new();
        protected Book book = new();
        protected string result = string.Empty;
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {

            await GetBook();
        }

        protected async Task GetBook()
        {
            bookList = await Http.GetFromJsonAsync<List<Book>>("api/Book");
            searchBookData = bookList;
        }

        protected void FilterBook()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                bookList = searchBookData
                    .Where(x => x.BookName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1 ||  x.Author.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1
                    || x.Category.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                bookList = searchBookData;
            }
        }

        protected void DeleteConfirm(int bookID)
        {
            book = bookList.FirstOrDefault(x => x.BookID == bookID);
        }

        protected async Task DeleteBook(int bookID)
        {


            await Http.DeleteAsync("api/Book/" + bookID);
            result = await Http.GetStringAsync("api/Book/string");
           ;
            await GetBook();
            Console.WriteLine(await Http.GetStringAsync("api/Book/string"));

        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            bookList = searchBookData;
        }
     
    }
}
