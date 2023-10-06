﻿using Microsoft.AspNetCore.Http.HttpResults;
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
                IsLogged = true;
            else IsLogged = false;

            //if (Request.Cookies["NewelCookie"] != null)
            //{
            //    Console.WriteLine("we here");
            //    string data = Request.Cookies["NewelCookie"].Substring(1, Request.Cookies["NewelCookie"].Length - 2);

            //    HttpResponseMessage message = await client.GetAsync($"https://localhost:7228/api/user/{data}");

            //    if (message.IsSuccessStatusCode)
            //    {
            //        string response = await message.Content.ReadAsStringAsync();
            //        model = JsonConvert.DeserializeObject<UserResponseModel>(response);

            //        if (model != null)
            //            IsLogged = true;
            //    }
            //    //else
            //    //    throw new ArgumentException(message.StatusCode.ToString());
            //    //model = new UserRequestModel();
            //}
            //else
            //{
            //    IsLogged = false;
            //}
        }
    }
}