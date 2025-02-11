using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo;

internal class Program
{
	/// <summary>
	/// EntityFramework
	/// Wird für Datenzugriff verwendet
	/// Kann für die gängigsten Datenbanken verwendet werden (z.B. SQL Server, MySQL, Postgres, SQLite, Oracle, ...)
	/// Legt in unserer C#-Anwendung Klassen an, welche die Datenbanktabellen repräsentieren
	/// Beim Laden der Daten, werden in der C#-Anwendung für jeden Datensatz Objekte erstellt
	/// 
	/// Anforderungen:
	/// - Datenbank
	/// - EFCore Standardpaket (NuGet: Microsoft.EntityFrameworkCore)
	/// - Entsprechendes EFCore Datenbankpaket (NuGet)
	/// - EFCore Power Tools (optional) (VS Extension)
	/// 
	/// Verwendung:
	/// - Rechtsklick aufs Projekt -> EFCore Power Tools -> Reverse Engineer
	/// 
	/// Output:
	/// - Context: Datenbankconnector (Wird verwendet, um Daten zu laden)
	/// - Model-Klassen: Stellen die Datenbanktabellen dar. Beim Laden der Daten wird jeder Datensatz zu einem Objekt des entsprechenden Typens
	/// </summary>
	static void Main(string[] args)
	{
		//Von der Context-Klasse ein Objekt erstellen, und die DbSets mit Linq ansprechen
		NorthwindContext db = new NorthwindContext();

		//SQL Statements werden aus Linq Statements generiert
		IQueryable<Customer> uk = db.Customers.Where(e => e.Country == "UK"); //SELECT * FROM Customers WHERE Country = 'UK'

		//Hier wurde noch nicht mit der DB interagiert
		//IQueryable erbt von IEnumerable
		//IEnumerable ist nur eine Anleitung zum Erstellen der fertigen Daten
		//Diese Anleitung kann ausgeführt werden, um die Daten zu bekommen
		//Anleitung ausführen mithilfe von einer foreach-Schleife
		List<Customer> customers = uk.ToList(); //Hier werden die Daten geladen

		foreach (Customer customer in customers)
		{
			Console.WriteLine(customer.CustomerId);
		}

		//Insert, Update, Delete
		//db.Add(new Customer() { CustomerId = "PPEDV", CompanyName = "ppedv AG" }); //Prüft, welche Tabelle diesen Datensatz enthalten soll, und fügt diesen ein
		//db.SaveChanges(); //Sendet die neuen Datensätze an die DB

		//db.Update(new Customer() { CustomerId = "PPEDV", CompanyName = "ppedv AG", ContactName = "Lukas Kern" });
		//db.SaveChanges(); //Sendet die neuen Datensätze an die DB

		db.Remove(new Customer() { CustomerId = "PPEDV" });
		db.SaveChanges();
	}
}