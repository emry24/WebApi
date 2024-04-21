using AutoMapper;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers;

//[Authorize]
public class CoursesController(HttpClient http, IMapper mapper) : Controller
{
    private readonly HttpClient _http = http;
    private readonly IMapper _mapper = mapper; 

    public async Task<IActionResult> Index()
    {
        var viewModel = new CourseResultModel();

        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7279/api/courses");
        if (response.IsSuccessStatusCode)
        {
            var courseResult = JsonConvert.DeserializeObject<CourseResultModel>(await response.Content.ReadAsStringAsync());
            viewModel.Courses = courseResult!.Courses;

            ViewData["Status"] = "Success";
        }
        else
        {
            ViewData["Status"] = "ConnectionFailed";
        }

        return View(viewModel);
    }


    //[HttpPost]
    //public async Task<IActionResult> Create(CourseRegistrationFormViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        using var http = new HttpClient();

    //        var json = JsonConvert.SerializeObject(viewModel);
    //        using var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        var response = await http.PostAsync("https://localhost:7279/api/courses", content);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            return RedirectToAction("Index", "Courses");
    //        }
    //    }

    //    return View(viewModel);
    //}


    [HttpPost]
    public async Task<IActionResult> Create(CourseModel courseModel)
    {

        if (ModelState.IsValid)
        {
            using var http = new HttpClient();

            var json = JsonConvert.SerializeObject(courseModel);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("https://localhost:7279/api/courses", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses");
            }
        }

        return View(courseModel);
    }



    [Route("/details")]
    public async Task<IActionResult> Details(string id)
    {

        var response = await _http.GetAsync($"https://localhost:7279/api/courses/{id}");
        var json = await response.Content.ReadAsStringAsync();
        var courseDto = JsonConvert.DeserializeObject<CourseDto>(json);

        var courseModel = new CourseModel
        {
            CourseId = courseDto.CourseId,
            Title = courseDto.Title,
            Ingress = courseDto.Ingress,
            IsBestseller = courseDto.IsBestseller,
            Reviews = courseDto.Reviews,
            RatingImage = courseDto.RatingImage,
            LikesInProcent = courseDto.LikesInProcent,
            LikesInNumbers = courseDto.LikesInNumbers,
            DurationHours = courseDto.DurationHours,
            Description = courseDto.Description,
            Creator = new CreatorModel
            {
                CreatorName = courseDto.Creator?.CreatorName,
                CreatorBio = courseDto.Creator?.CreatorBio,
                CreatorImage = courseDto.Creator?.CreatorImage,
                FacebookFollowers = courseDto.Creator?.FacebookFollowers,
                YoutubeSubscribers = courseDto.Creator?.YoutubeSubscribers,
            },
            Category = new CategoryModel
            {
                CategoryName = courseDto.Category.CategoryName
            },
            Details = new CourseDetailsModel
            {
                NumberOfArticles = courseDto.Details.NumberOfArticles,
                NumberOfResources = courseDto.Details.NumberOfResources,
                LifetimeAccess = courseDto.Details.LifetimeAccess,
                Certificate = courseDto.Details.Certificate,
                Price = courseDto.Details.Price,
                DiscountedPrice = courseDto.Details.DiscountedPrice,
            },
            ProgramDetails = courseDto.ProgramDetails?.Select(pd => new ProgramDetailsModel
            {
                ProgramDetailsNumber = pd.ProgramDetailsNumber,
                ProgramDetailsTitle = pd.ProgramDetailsTitle,
                ProgramDetailsDescription = pd.ProgramDetailsDescription,
            }).ToList(),
            LearningDetails = courseDto.LearningDetails?.Select(ld => new LearningDetailsModel
            {
                LearningsDescription = ld.LearningsDescription,
            }).ToList()
        };

        return View(courseModel);
    }
}
