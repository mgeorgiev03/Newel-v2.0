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

        public RegisterModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()  
        {
            UserRequestModel model = new UserRequestModel();
            model.Name = Request.Form["name"];
            model.Email = Request.Form["email"];
            model.Password = Request.Form["password"];

            var modelContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:7228/api/user", modelContent);
            //make a http post request to server
            return RedirectToPage(response);
        }
    }
}
