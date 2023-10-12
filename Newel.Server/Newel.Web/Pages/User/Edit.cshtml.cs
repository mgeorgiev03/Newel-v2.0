using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.User;
using Newtonsoft.Json;
using System.Text;

namespace Newel.Web.Pages.User
{
    public class EditModel : PageModel, ILogIn
    {
        public UserRequestModel Model { get; set; } = new UserRequestModel();
        public bool IsLogged { get => true; set { IsLogged = true; } }

        private readonly HttpClient client;

        public EditModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task OnGet()
        {
        }

        public async Task OnPost()
        {
            string data = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);

            HttpResponseMessage message = await client.GetAsync($"https://localhost:7228/api/user/{data}");


            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                UserResponseModel model = JsonConvert.DeserializeObject<UserResponseModel>(response);

                if (Request.Form["name"] == string.Empty)
                    Model.Name = model.Name;
                else
                    Model.Name = Request.Form["name"];



                if (Request.Form["email"] == string.Empty)
                    Model.Email = model.Email;
                else
                    Model.Email = Request.Form["email"];

                Model.Password = model.Password;

                var modelContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

                await client.PutAsync($"https://localhost:7228/api/user/{data}", modelContent);
            }
            else
                RedirectToPage("/Error", message.StatusCode);

        }
    }
}
