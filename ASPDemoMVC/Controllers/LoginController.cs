using ASPDemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDemoMVC.Controllers;

/// <summary>
/// Aufgabenstellung: Simples Login Formular
/// </summary>
public class LoginController : Controller
{
	private List<User> _users;

	public LoginController(List<User> users) => _users = users;

	public IActionResult Index()
	{
		return View();
	}

	/// <summary>
	/// IActionResult
	/// Stellt eine Response an den User dar
	/// Wird als HTTP Code zurückgegeben (z.B. 200, 400, 401, 403, 404, 500, ...)
	/// </summary>
	public IActionResult Login()
	{
		return View();
	}

	public IActionResult Einloggen(string username, string passwort)
	{
		//User finden
		User? u = _users.FirstOrDefault(e => e.UserName == username);
		if (u == null)
			return NotFound();

		//Ist das Passwort korrekt?
		if (u.Password != passwort)
			return Forbid();

		return View("Index", u);
	}
}
