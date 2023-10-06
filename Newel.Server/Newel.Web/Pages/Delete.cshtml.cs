using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace Newel.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client;
        private Guid modelId;

        public DeleteModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("we here");

            string id = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);
            await client.PostAsync($"https://localhost:7228/api/account/{id}", null);

            modelId = Guid.Parse(id); 

            //remove cookie
            Response.Cookies.Delete("NewelCookie");

            return RedirectToPage("/Index");
        }
    }
}
