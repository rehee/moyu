using Microsoft.AspNetCore.Mvc;
using MoYu.Api.Data;
using MoYu.Api.Models;
using MoYu.Entities.Characters;
using MoYu.Entities.Items.Equipments;
using System.Diagnostics;

namespace MoYu.Api.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
      _logger = logger;
      this.db = db;
    }

    public IActionResult Index()
    {

      return Content("");
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}