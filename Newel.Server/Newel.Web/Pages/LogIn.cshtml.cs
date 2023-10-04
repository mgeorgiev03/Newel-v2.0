using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.User;
using Newtonsoft.Json;
using System.Text;

namespace Newel.Web.Pages
{
    public class LogInModel : PageModel
    {
        private readonly HttpClient client;
        [BindProperty]
        public LogInRequest Model { get; set; }

        public LogInModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var data = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json") ;
            //autherntication not create
            HttpResponseMessage response = await client.PostAsync("https://localhost:7228/api/account", data);

            string responseBody = await response.Content.ReadAsStringAsync();

            HttpContext.Response.Cookies.Append("NewelCookie", responseBody);


            return RedirectToPage("/Index");
        }
    }
}
