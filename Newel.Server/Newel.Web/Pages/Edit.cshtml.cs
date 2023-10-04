using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newel.Web.Models.User;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Newel.Web.Pages
{
    public class EditModel : PageModel
    {
        public UserRequestModel Model { get; set; }

        private readonly HttpClient client;

        public EditModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task OnGet()
        {
        }

        public async Task OnPut()
        {
            //get user id rom cookie
            string data = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);

            HttpResponseMessage message = await client.GetAsync($"https://localhost:7228/api/user/{data}");
            UserResponseModel model = new UserResponseModel();

            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<UserResponseModel>(response);

            }
            else 
                RedirectToPage("/Error", message.StatusCode);

            //update

            if (Request.Form["name"] == string.Empty)
                Model.Name = model.Name;
            else
                Model.Name = Request.Form["name"].ToString();

            if (Request.Form["email"] == string.Empty)
                Model.Email = model.Email;
            else
                Model.Email = Request.Form["email"].ToString();



            Model.Password = model.Password;

            var modelContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            await client.PutAsync($"https://localhost:7228/api/user/{data}", modelContent);
        }
    }
}
