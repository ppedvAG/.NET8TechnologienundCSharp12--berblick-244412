using ASPDemoMVC.Models;
using EntityFrameworkDemo.Models;

namespace ASPDemoMVC;

public class Program
{
	/// <summary>
	/// launchSettings.json: Setzt Starteinstellung von dem Projekt (generell unverändert)
	/// wwwroot: Enthält statische Dateien (JavaScript, CSS)
	/// appsettings.json/appsettings.Development.json: Enthält die Einstellungen des Webservers
	/// Program.cs: Dependency Injection & Middleware
	/// </summary>
	public static void Main(string[] args)
	{
		//Dependency Injection
		//In der Program.cs werden Objekte registriert
		//Diese werden dann zur Laufzeit an die Controller/Pages weitergegeben
		//Der DI-Manager verwaltet alle Objekte; die Controller/Pages können sich Objekte nehmen, wenn sie diese benötigen

		//Registrierung von Objekten
		//AddSingleton: Legt ein einziges Objekt für alle User an
		//AddTransient: Legt ein Objekt pro User an, dieses bleibt erhalten, solange der User auf unserer Webseite navigiert
		//AddScoped: Legt pro HTTP Request ein neues Objekt an

		WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllersWithViews();

		//Aufgabe: Pro User einen DB Context (NorthwindContext) anlegen
		builder.Services.AddTransient<NorthwindContext>();

		List<User> users = [new User() { UserName = "LukasK@ppedv.de", Password = "123" }];
		builder.Services.AddSingleton(users);

		WebApplication app = builder.Build();

		/////////////////////////////////////////////////////////////////////////////////////

		//Middleware
		//Verändern die Pipeline von HTTP-Requests
		//Wenn ein Request von einem User hereinkommt, wird diese Pipeline in der angegebenen Reihenfolge abgearbeitet

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");

			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseRouting();

		app.UseStatusCodePages();

		//app.UseAuthentication();
		//app.UseAuthorization();

		app.MapStaticAssets();
		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}")
			.WithStaticAssets();

		app.Run();
	}
}
