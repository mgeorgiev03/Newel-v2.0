using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.User;
using Newtonsoft.Json;

namespace Newel.Web.Pages
{
    public class IndexModel : PageModel
    {
        public UserResponseModel? model;
        public bool IsLogged = false;
        private readonly HttpClient client;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, HttpClient _client)
        {
            _logger = logger;
            client = _client;
        }

        public async Task OnGet()
        {
            if (Request.Cookies["NewelCookie"] != null)
            {
                string data = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);
                
                HttpResponseMessage message = await client.GetAsync($"https://localhost:7228/api/user/{data}");

                if (message.IsSuccessStatusCode)
                {
                    string response = await message.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<UserResponseModel>(response);


                    Console.WriteLine("Model name " + model.Name);

                    if (model != null)
                    {
                        IsLogged = true;
                        Console.WriteLine(IsLogged);
                    }

                }
                else
                    throw new ArgumentException(message.StatusCode.ToString());
                //model = new UserRequestModel();



            }
        }
    }
}