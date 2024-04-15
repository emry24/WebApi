//using Infrastructure.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System.Text;
//using WebApp.Models;

//namespace WebApp.Controllers;

//public class SubscribersController(HttpClient http) : Controller
//{
//    private readonly HttpClient _http = http;
//    public IActionResult Index()
//    {
//        var viewModel = new SubscribeViewModel();
//        return View(viewModel);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Index(SubscribeViewModel viewModel)
//    {
//        if (ModelState.IsValid)
//        {
//            try
//            {
//                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
//                var response = await _http.PostAsync("https://localhost:7279/api/subscribers", content);

//                if (response.IsSuccessStatusCode)
//                {
//                    ViewData["Status"] = "Success";
//                }
//                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
//                {
//                    ViewData["Status"] = "AlreadyExists";
//                }
//            }
//            catch
//            {
//                ViewData["Status"] = "ConnectionFailed";
//            }
//        }
//        else
//        {
//            ViewData["Status"] = "Invalid";
//        }

//        return View(viewModel);
//    }

    //[HttpPost]
    //public async Task<IActionResult> Index(SubscribeViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        using var http = new HttpClient();

    //        var url = $"https://localhost:7279/api/subscribers?email={viewModel.Email}";
    //        var request = new HttpRequestMessage(HttpMethod.Post, url);

    //        var response = await http.SendAsync(request);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            viewModel.IsSubscribed = true;
    //        }
    //    }
    //    return View(viewModel);
    //}
//}

