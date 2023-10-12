using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newel.Web.Models.List;
using Newel.Web.Models.User;
using Newel.Web.Pages.User;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Newel.Web.Pages
{
    public class IndexModel : PageModel, ILogIn
    {
        public UserResponseModel? Model { get; set; }
        public bool IsLogged { get; set; }
        private readonly HttpClient client;
        public List<ListResponseModel> userLists;


        [BindProperty]
        public ListResponseModel CurrentList { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, HttpClient _client)
        {
            _logger = logger;
            client = _client;

            userLists = new List<ListResponseModel>();
            CurrentList = new ListResponseModel();
        }

        public async Task OnGet()
        {
            if (Request.Cookies["NewelCookie"] != null)
            {
                string id = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7228/api/user/{id}");

                string data = await response.Content.ReadAsStringAsync();

                Model = JsonConvert.DeserializeObject<UserResponseModel>(data);

                IsLogged = true;

                HttpResponseMessage listsRequest = await client.GetAsync($"https://localhost:7228/api/list/");

                if (listsRequest.IsSuccessStatusCode)
                {
                    string listData = await listsRequest.Content.ReadAsStringAsync();

                    userLists = JsonConvert.DeserializeObject<List<ListResponseModel>>(listData);

                    userLists = userLists.Where(l => l.UserId.ToString() == id).ToList();

                }


                if (Request.Cookies["ListCookie"] != null)
                {
                    CurrentList.Id = Guid.Parse(Request.Cookies["ListCookie"]);

                    HttpResponseMessage listResponse = await client.GetAsync($"https://localhost:7228/api/list/{CurrentList.Id}");

                    if (listResponse.IsSuccessStatusCode)
                    {
                        string listData = await listResponse.Content.ReadAsStringAsync();
                        ListResponseModel temp = JsonConvert.DeserializeObject<ListResponseModel>(listData);

                        CurrentList.Name = temp.Name;
                        CurrentList.UserId = temp.UserId;
                    }
                }

            }
            else
                IsLogged = false;

        }

        public IActionResult OnPostForm1()
        {
            Console.WriteLine("current list: " + CurrentList.Id);

            var id = Request.Form["listName"];
            Console.WriteLine("current list: " + id);

            string cookieListId = Request.Cookies["ListCookie"];

            if (cookieListId == null)
                Response.Cookies.Append("ListCookie", CurrentList.Id.ToString());
            else if (cookieListId != CurrentList.Id.ToString())
            {
                Response.Cookies.Delete("ListCookie");
                Response.Cookies.Append("ListCookie", CurrentList.Id.ToString());
            }

            return RedirectToPage();
        }
    }
}