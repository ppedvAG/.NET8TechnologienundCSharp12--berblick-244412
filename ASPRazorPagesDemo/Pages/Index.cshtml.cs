using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPRazorPagesDemo.Pages;

public class IndexModel : PageModel
{
	private readonly ILogger<IndexModel> _logger;

	public IndexModel(ILogger<IndexModel> logger)
	{
		_logger = logger;
	}

	public void OnGetIndex()
	{
		//return View();
	}

	public IActionResult OnGetLogin()
	{
		return Page(); // == return View();
	}

	public void OnPostEinloggen(string username, string password)
	{

	}
}
