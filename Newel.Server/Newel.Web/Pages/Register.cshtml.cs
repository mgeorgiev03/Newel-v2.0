using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.User;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Newel.Web.Pages
{
    public class RegisterModel : PageModel
    {
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

            string content = await modelContent.ReadAsStringAsync(); 
            Console.WriteLine(content);


            HttpResponseMessage response = await client.PostAsync("https://localhost:7228/api/user", modelContent);
            
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                HttpContext.Response.Cookies.Append("NewelCookie", responseBody);

            return RedirectToPage("/Index");
        }
    }
}
