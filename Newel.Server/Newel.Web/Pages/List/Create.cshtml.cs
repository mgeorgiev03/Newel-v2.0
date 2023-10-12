using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.List;
using Newel.Web.Pages.User;
using Newtonsoft.Json;
using System.Text;

namespace Newel.Web.Pages.List
{
    public class CreateModel : PageModel, ILogIn
    {
        public bool IsLogged { get => true; set { IsLogged = true; } }
        private HttpClient client;

        public CreateModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            ListRequestModel model = new ListRequestModel();
            model.Name = Request.Form["name"];

            string id = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);
            model.UserId = Guid.Parse(id);

            var modelContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage message = await client.PostAsync("https://localhost:7228/api/list", modelContent);

            if (message.IsSuccessStatusCode)
            {
                string listId = await message.Content.ReadAsStringAsync();
                Response.Cookies.Append("NewelList", listId);
            }

            return RedirectToPage("/Index");
        }
    }
}
