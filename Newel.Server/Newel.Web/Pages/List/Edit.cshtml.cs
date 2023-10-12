using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.List;
using Newtonsoft.Json;
using System.Text;

namespace Newel.Web.Pages.List
{
    public class EditModel : PageModel
    {
        public bool IsLogged { get => true; set { IsLogged = true; } }
        private readonly HttpClient client;

        public EditModel(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            ListRequestModel model = new ListRequestModel();
            model.Name = Request.Form["name"];
            model.UserId = Guid.Parse(Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2));

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "aplication/json");

            string data = await content.ReadAsStringAsync();
            Console.WriteLine(data);

            string id = Request.Cookies["ListCookie"];
            await client.PutAsync($"https://localhost:7228/api/list/{id}", content);

        }
    }
}
