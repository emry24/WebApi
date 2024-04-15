using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;
    public IActionResult Index()
    {
        var viewModel = new SubscribeViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(SubscribeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (viewModel.DailyNewsletter || viewModel.AdvertisingUpdates || viewModel.WeekInReview || viewModel.EventUpdates || viewModel.StartUpsWeekly || viewModel.Podcasts)
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                    var response = await _http.PostAsync("https://localhost:7279/api/subscribers?key=YTc4YTQ3ZjMtYjNiZC00Mzc2LTlmM2MtZGQ3MDg0ZGI0YzNk", content);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["Status"] = "Success";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        ViewData["Status"] = "AlreadyExists";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        ViewData["Status"] = "Unauthorized";
                    }
                }
                catch
                {
                    ViewData["Status"] = "ConnectionFailed";
                }
            }
            else
            {
                ViewData["Status"] = "AtLeastOneCheckboxRequired";
            }
        }
        else
        {
            ViewData["Status"] = "Invalid";
        }

        return View(viewModel);
    }

}
