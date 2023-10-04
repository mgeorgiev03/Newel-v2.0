using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Newel.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client;

        public DeleteModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {
        }

        public async Task OnDelete()
        {
            string id = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);
            await client.DeleteAsync($"https://localhost:7228/api/user/{id}");
        }
    }
}
