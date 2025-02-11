using IntList = System.Collections.Generic.List<int>;

namespace Sprachfeatures;

internal unsafe class Program
{
	public int ClassStructTest;

	static unsafe void Main(string[] args)
	{
		//out: Mehrere Rückgabewerte bei einer Funktion
		//Wenn ein out-Parameter definiert ist, muss hier eine Variable angelegt werden
		//int ergebnis;
		bool funktioniert = int.TryParse("ABC", out int ergebnis); //Wenn das Parsen funktioniert, steht die Zahl in der Variable

		//Unterschied zw. is und GetType() == typeof(...)
		//is: Vererbungshierarchie wird berücksichtigt
		//typeof: Genauer Typvergleich
		object o = 123;
		if (o is int)
		{
			//...
		}

		if (o.GetType() == typeof(int))
		{
			//...
		}

		//Tupel
		(int Zahl, string Text, bool WF) x = (0, "Hallo", false); //Item1, Item2, Item3
		object[] y = []; //[0], [1], [2]
		Console.WriteLine(x.Zahl);
		Console.WriteLine(x.Text);
		Console.WriteLine(x.WF);

		//Lokale Funktion: Kann nur innerhalb der Main-Methode verwendet werden
		void Test()
		{
			Console.WriteLine("Hallo Welt");
		}

		Test();

		double d = 214_123_489_141.314_981_922;

		//class und struct

		//class
		//Referenztyp
		//Eine Variable von einem Typ einer Klasse, hat immer einen Zeiger (Pointer) auf ein Objekt im Arbeitsspeicher
		Program p = new Program(); //Objekt erstellen und Zeiger anlegen
		Program p2 = p; //Weiteren Zeiger anlegen, welcher auf das Objekt unter p zeigt
		p.ClassStructTest = 10; //Hier werden beide Variablen verändert, weil dasselbe Objekt unter beiden Variablen ist

		//struct
		//Wertetyp
		//Wenn ein Struct zugewiesen wird, wird eine Kopie des Wertes erzeugt
		int z = 10;
		int neu = z;
		z = 20;

		//ref
		//Gibt die Möglichkeit, Referenzen mit Structs zu machen
		int z2 = 10;
		ref int neu2 = ref z2;
		z2 = 20;

		unsafe
		{

		}

		//Switch-Pattern
		int a = 1;
		string zahl = a switch
		{
			< 0 => "kleiner 0",
			1 => "Eins",
			2 => "Zwei",
			3 => "Drei",
			> 4 => "größer 3"
		};

		switch (a)
		{
			case < 0:
				zahl = "kleiner 0";
				break;
			case 1:
				zahl = "Eins";
				break;
			case 2:
				zahl = "Zwei";
				break;
			case 3:
				zahl = "Drei";
				break;
			case > 3:
				zahl = "größer 3";
				break;
		}

		string Test2(DayOfWeek d) => d switch
		{
			DayOfWeek.Sunday => throw new NotImplementedException(),
			DayOfWeek.Monday => throw new NotImplementedException(),
			DayOfWeek.Tuesday => throw new NotImplementedException(),
			DayOfWeek.Wednesday => throw new NotImplementedException(),
			DayOfWeek.Thursday => throw new NotImplementedException(),
			DayOfWeek.Friday => throw new NotImplementedException(),
			DayOfWeek.Saturday => throw new NotImplementedException(),
			_ => "anderer Tag"
		};

		//Null-Coalescing Operator (??-Operator): Nimm die linke Seite, wenn diese nicht null ist, sonst nimm die rechte Seite
		string str = "Hallo"; //String printen, wenn dieser nicht null ist, sonst Fehlermeldung ausgeben

		if (str != null)
			Console.WriteLine(str);
		else
			Console.WriteLine("string ist leer");

		//?-Operator
		Console.WriteLine(str != null ? str : "string ist leer");

		//??-Operator
		Console.WriteLine(str ?? "string ist leer");

		//String-Interpolation ($-String): Code in einen String einbauen
		int a1 = 10;
		int a2 = 20;
		int a3 = 30;

		//Aufgabe: Alle drei Zahlen in einer schönen Ausgabe ausgeben
		Console.WriteLine("Die erste Zahl ist: " + a1 + ", die zweite Zahl ist: " + a2 + ", die dritte Zahl ist: " + a3);
		Console.WriteLine($"Die erste Zahl ist: {a1}, die zweite Zahl ist: {a2}, die dritte Zahl ist: {a3}");

		Console.WriteLine($"Die Summe der drei Zahlen ist: {a1 + a2 + a3}");

		Console.WriteLine($"Die Zahl 38914712.2148712849 auf zwei Kommastellen gerundet ist: {Math.Round(38914712.2148712849, 2)}");

		Console.WriteLine($"Die Zahlen sind: {(a1 + a2 + a3 % 2 == 0 ? "gerade" : "ungerade")}");

		//Verbatim-String (@-String): String, welcher Escape-Sequenzen ignoriert
		string pfad = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\9.0.0\\System.Security.Claims.dll";
		string pfad2 = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\9.0.0\System.Security.Claims.dll";

		//List<int> zahlen = new List<int>();
		List<int> zahlen = new();

		Person person = new Person("Max Mustermann", "Max", "Mustermann", 30, 1_123_456_789);
		//(string n, string f, string l, int age, int b) = person; //Hier wird Deconstruct verwendet

		Console.WriteLine($"Hallo \"Welt\" ");
		Console.WriteLine($"""Hallo "Welt" """);

		Console.WriteLine($"Geschwungene Klammer auf: {{{a}");
		Console.WriteLine($$"""Geschwungene Klammer auf: {{{a}}""");

		//Collection Expression
		int[] nummern = { 1, 2, 3, 4, 5 };
		List<int> ints = new() { 1, 2, 3, 4, 5 };

		ints = [1, 2, 3, 4, 5];

		List<int> gesamt = [.. nummern, .. ints]; //Zerlegungsoperator: Nimmt aus einer Liste die einzelnen Zahlen [1, 2, 3, 4, 5, 1, 2, 3, 4, 5]

		IntList il = new(); //Alias: Beliebige Typen umbenennen

		Summe(1, 2, 3);
		Summe(1, 2, 3, 4, 5);
		Summe(1);
		Summe();
	}

	static (bool, int) TryParse(string x)
	{
		if (int.TryParse(x, out int ergebnis))
			return (true, ergebnis);
		return (false, 0);
	}

	static void Summe(params List<int> list)
	{
		Console.WriteLine(list.Sum());
	}
}

//public class Person
//{
//	public string Name { get; set; }

//	public string FirstName { get; set; }

//	public string LastName { get; set; }

//	public int Age { get; set; }

//	public int Birth { get; set; }

//	public Person(string name, string firstName, string lastName, int age, int birth)
//	{
//		Name = name;
//		FirstName = firstName;
//		LastName = lastName;
//		Age = age;
//		Birth = birth;
//	}
//}

//public record Person(string Name, string FirstName, string LastName, int Age, int Birth);

public class Person(string name, string firstName, string lastName, int age, int birth)
{
	public string Name { get; set; } = name;

	public string FirstName { get; set; } = firstName;

	public string LastName { get; set; } = lastName;

	public int Age { get; set; } = age;

	public int Birth { get; set; } = birth;
}