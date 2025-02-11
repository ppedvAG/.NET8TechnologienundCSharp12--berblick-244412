namespace DelegatesEvents;

/// <summary>
/// Anwenderseite
/// </summary>
public class User
{
	static void Main(string[] args)
	{
		Component c = new Component();

		c.Start += C_Start;
		c.Progress += C_Progress;
		c.Stop += C_Stop;

		c.Run();
	}

	private static void C_Progress(int obj)
	{
		Console.WriteLine($"Fortschritt: {obj}");
	}

	private static void C_Start()
	{
		Console.WriteLine("Prozess gestartet");
	}

	private static void C_Stop()
	{
		Console.WriteLine("Prozess fertig");
	}
}
