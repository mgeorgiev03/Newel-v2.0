using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.User;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Newel.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly HttpClient client;

        [BindProperty]
        public LogInRequest Model { get; set; }

        public RegisterModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()  
        {
            var modelContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:7228/api/user", modelContent);
            
            string responseBody = await response.Content.ReadAsStringAsync();

            HttpContext.Response.Cookies.Append("NewelCookie", responseBody);

            return RedirectToPage("/Index");
        }
    }
}
