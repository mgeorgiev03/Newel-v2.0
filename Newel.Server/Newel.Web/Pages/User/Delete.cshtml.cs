using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace Newel.Web.Pages.User
{
    public class DeleteModel : PageModel, ILogIn
    {
        private readonly HttpClient client;
        public bool IsLogged { get => true; set { IsLogged = true; } }

        public DeleteModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string id = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);
            await client.PostAsync($"https://localhost:7228/api/account/{id}", null);

            Response.Cookies.Delete("NewelCookie");
            Response.Cookies.Delete("ListCookie");

            return RedirectToPage("/Index");
        }
    }
}
