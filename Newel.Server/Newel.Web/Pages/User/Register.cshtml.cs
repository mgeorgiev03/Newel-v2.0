using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.User;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Newel.Web.Pages.User
{
    public class RegisterModel : PageModel, ILogIn
    {
        public bool IsLogged { get => false; set { IsLogged = false; } }
        private readonly HttpClient client;

        //[BindProperty]
        public UserRequestModel Model { get; set; }

        public RegisterModel(HttpClient httpClient)
        {
            client = httpClient;
            Model = new UserRequestModel();
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Request.Cookies["NewelCookie"] != null)
                Response.Cookies.Delete("NewelCookie");


            Model.Name = Request.Form["name"];
            Model.Email = Request.Form["email"];
            Model.Password = Request.Form["password"];

            var modelContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:7228/api/user", modelContent);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                HttpContext.Response.Cookies.Append("NewelCookie", responseBody);
            }

            return RedirectToPage("/Index");
        }
    }
}
