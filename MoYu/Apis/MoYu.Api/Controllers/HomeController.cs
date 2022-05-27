using Microsoft.AspNetCore.Mvc;
using MoYu.Api.Data;
using MoYu.Api.Models;
using MoYu.Common.Items;
using MoYu.Entities.Characters;
using MoYu.Entities.Items.Equipments;
using System.Diagnostics;

namespace MoYu.Api.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IItemService itemService;

    public HomeController(ILogger<HomeController> logger, IItemService itemService)
    {
      _logger = logger;
      this.itemService = itemService;
    }

    public IActionResult Index()
    {
      var randomItem = itemService.DropWeapon(99);
      itemService.SetAffixes(randomItem);
      return Ok(randomItem);
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