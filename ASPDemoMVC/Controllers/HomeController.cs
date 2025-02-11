using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDemoMVC.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	private readonly NorthwindContext _db;

	public HomeController(ILogger<HomeController> logger, NorthwindContext db)
	{
		_logger = logger;
		_db = db;
	}

	/// <summary>
	/// Hängt mit /Home/Index.cshtml zusammen
	/// </summary>
	public IActionResult Index()
	{
		return View();
	}

	/// <summary>
	/// Hängt mit /Home/Privacy.cshtml zusammen
	/// </summary>
	public IActionResult Privacy()
	{
		return View();
	}

	/// <summary>
	/// Hängt mit /Home/Data.cshtml zusammen
	/// </summary>
	public IActionResult Data()
	{
		List<Customer> kunden = _db.Customers.ToList(); //Kunden laden

		return View(kunden); //Kunden an das HTML weitergeben
	}
}
