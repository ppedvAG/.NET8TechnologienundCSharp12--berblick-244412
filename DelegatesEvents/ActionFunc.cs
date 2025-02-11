namespace DelegatesEvents;

internal class ActionFunc
{
	/// <summary>
	/// Action & Func
	/// Sind selbst zwei Delegatetypen, welche jeweils an sehr vielen Stellen in C# verwendet werden
	/// Beispiele: Linq, TPL, Reflection, WinForms/WPF/MAUI Events, ASP.NET Core DI/Middleware, ...
	/// 
	/// Werden hauptsächlich als Parameter von Funktion/Konstruktoren verwendet, 
	/// um dem User zu ermöglichen, beliebigen Code an die Funktion/den Konstruktor weiterzugeben
	/// </summary>
	static void Main(string[] args)
	{
		//Action: Methodenzeiger mit void und bis zu 16 Parametern
		//Aufgabe: Action, welche eine Addiere Funktion empfangen kann
		Action<int, int> a = new Action<int, int>(Addiere);
		a?.Invoke(4, 5);

		//Beispiel: ForEach
		//Die ForEach Funktion benötigt als Parameter einen Methodenzeiger, welcher für jedes Element der Liste ausgeführt wird
		//Der Methodenzeiger hat auch einen Parameter, welcher das derzeitige Listenelement darstellt
		List<int> list = Enumerable.Range(0, 20).ToList();
		list.ForEach(PrintZahl); //Aufbau des Funktionszeigers: void <Name>(int x)
		//list.ForEach(Addiere); //Nicht kompatibel

		List<string> namen = ["Max", "Udo", "Tim"];
		namen.ForEach(PrintName); //Aufbau des Funktionszeigers: void <Name>(string x)
		//namen.ForEach(PrintZahl); //Nicht kompatibel

		Berechne(4, 9, Addiere);
		Berechne(4, 9, Subtrahiere);

		/////////////////////////////////////////////////////////////////////////////////////////////////

		//Func: Funktioniert wie Action, hat aber einen Rückgabewert
		//Methodenzeiger mit T und bis zu 16 Parametern
		Func<int, int, double> f = Dividiere; //Der Rückgabewert von Func ist immer der letzte Parameter
		double d = f(4, 3); //Bei einer Func kommt immer ein Ergebnis heraus; dieses kann in eine Variable gespeichert werden
		Console.WriteLine($"Ergebnis: {d}");

		//Beispiel: Where
		list.Where(TeilbarDurch2); //Aufbau des Funktionszeigers: bool <Name>(int x)

		/////////////////////////////////////////////////////////////////////////////////////////////////

		//Anonyme Methode
		//Methoden, welche nicht separat angelegt werden, sondern nur in einer Variable gespeichert werden

		//Aufbauten über die Jahre in C#
		f += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		f += (int x, int y) => { return x + y; }; //Kürzere Form

		f += (x, y) => { return x - y; };

		f += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		//Anonyme Methoden werden häufig als Parameter für Delegates verwendet (z.B. Where, ForEach, ...)

		//Ohne Anonyme Methode
		list.Where(TeilbarDurch2);

		//Mit Anonymer Methode
		Func<int, bool> td2 = x => x % 2 == 0; //Anonyme Funktion in einer Variable
		list.Where(td2);

		//Direkt
		list.Where(x => x % 2 == 0); //Ohne separate Variable

		//Überall wo ein Delegate verlangt wird (Action, Func, ...), kann auch eine anonyme Funktion eingesetzt werden
	}

	#region Action
	static void Addiere(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");

	static void Subtrahiere(int x, int y) => Console.WriteLine($"{x} - {y} = {x - y}");

	static void PrintZahl(int x) => Console.WriteLine(x);

	static void PrintName(string x) => Console.WriteLine(x);

	static void Berechne(int x, int y, Action<int, int> a)
	{
		if (a == null)
			throw new ArgumentException(nameof(a));

		Console.WriteLine($"Die erste Zahl ist: {x}");
		Console.WriteLine($"Die zweite Zahl ist: {y}");
		Console.WriteLine($"Name der Action: {a.Method.Name}");
		a.Invoke(x, y);
	}
	#endregion

	#region Func
	static double Dividiere(int x, int y)
	{
		return (double) x / y;
	}

	static bool TeilbarDurch2(int x)
	{
		return x % 2 == 0;
	}
	#endregion
}
