using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DelegatesEvents;

internal class Events
{
	/// <summary>
	/// Events
	/// Schnittstelle für andere Entwickler, um Code anzuhängen
	/// 
	/// Besteht immer aus einem Delegate (meistens EventHandler) + dem Event Keyword
	/// 
	/// Idee:
	/// - Zweiseitige Programmierung
	/// - Entwicklerseite: Legt das Event an, und führt dieses aus
	/// - Anwenderseite: Hängt eine Methode an das Event, welche bei Ausführung des Events passieren soll
	/// 
	/// Drei Teile:
	/// - Das Event selbst (mit event-Keyword)
	/// - Ausführen des Events
	/// - Anhängen der Methode
	/// 
	/// Beispiele: WinForms/WPF/MAUI, ObservableCollection
	/// </summary>
	static void Main(string[] args) => new Events().Start(); //static-Modifier entfernen

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// EventHandler: Standarddelegate, welches für Events verwendet wird
	/// </summary>
	public event EventHandler TestEvent; //Entwicklerseite

	public event EventHandler<int> IntEvent; //Sollte ein Untertyp von EventArgs sein

	public event Action<int> IntActionEvent; //Bei events kann ein beliebiges Delegate verwendet werden (hier Action)

	public void Start()
	{
		TestEvent += Events_TestEvent; //Anwenderseite
		TestEvent(this, EventArgs.Empty); //Entwicklerseite

		/////////////////////////////////////////////////////////

		IntEvent += Events_IntEvent; //Anwenderseite
		IntEvent(this, 5); //Entwicklerseite

		/////////////////////////////////////////////////////////

		IntActionEvent += Events_IntActionEvent; //Anwenderseite
		IntActionEvent(10); //Entwicklerseite

		/////////////////////////////////////////////////////////

		ObservableCollection<int> zahlen = [];
		zahlen.CollectionChanged += Zahlen_CollectionChanged;
		zahlen.Add(1);
		zahlen.Add(2);
		zahlen.Add(3);
		zahlen.Remove(1);
	}

	private void Zahlen_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		//Console.WriteLine("Collection hat sich verändert");

		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				Console.WriteLine($"Element hinzugefügt: {e.NewItems[0]}");
				break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Element entfernt: {e.OldItems[0]}");
				break;
		}
	}

	/// <summary>
	/// sender: Objekt, welches das Event gefeuert hat
	/// EventArgs: Daten, welche beim Event mitgegeben werden können
	/// </summary>
	private void Events_TestEvent(object? sender, EventArgs e)
	{
		Console.WriteLine("TestEvent wurde ausgeführt");
	}

	private void Events_IntEvent(object? sender, int e)
	{
		Console.WriteLine($"Die Zahl ist: {e}");
	}

	private void Events_IntActionEvent(int obj)
	{
		Console.WriteLine($"Die Zahl ist: {obj}");
	}
}
