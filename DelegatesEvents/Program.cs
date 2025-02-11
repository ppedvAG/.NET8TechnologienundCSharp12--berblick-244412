namespace DelegatesEvents;

internal class Program
{
	/// <summary>
	/// Delegates
	/// Behälter für Methodenzeiger
	/// Das Delegate kann ausgeführt werden (wie eine Methode), und führt dann alle Methoden die angehängt sind
	/// Werden mithilfe des Delegate Keywords erstellt
	/// </summary>
	public delegate void Vorstellung(string name);

	static void Main(string[] args)
	{
		Vorstellung v = new Vorstellung(VorstellungDE); //Erstellung des Delegates mit einer Startmethode
		v("Max");

		v += VorstellungEN; //Mit += können Methoden angehängt werden
		v("Udo");

		v += VorstellungEN;
		v += VorstellungEN;
		v += VorstellungEN; //Die gleiche Methode kann auch mehrmals angehängt werden
		v("Tim");

		v -= VorstellungDE; //Mit -= können Methoden abgehängt werden
		v("Max");

		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN;
		//v("Udo"); //Wenn alle Methoden von einem Delegate abgenommen werden, ist dieses null

		if (v is not null)
			v("Udo");

		v?.Invoke("Udo"); //Null propagation: Führe den Code nach dem Fragezeichen aus, wenn die Variable davor nicht null ist

		//Delegate durchgehen
		foreach (Delegate dg in v.GetInvocationList())
		{
			Console.WriteLine(dg.Method.Name); //Von dem Methodenzeiger die Methode entnehmen, und den Namen dieser Methode ausgeben
		}
	}

	static void VorstellungDE(string name)
	{
		Console.WriteLine($"Hallo mein Name ist {name}");
	}

	static void VorstellungEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}
}
