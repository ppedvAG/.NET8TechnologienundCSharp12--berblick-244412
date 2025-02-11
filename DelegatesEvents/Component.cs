namespace DelegatesEvents;

/// <summary>
/// Entwicklerseite
/// </summary>
public class Component
{
	public event Action Start;

	public event Action Stop;

	public event Action<int> Progress;

	/// <summary>
	/// Simuliert einen langandauernden Prozess (z.B. DB Update, ...)
	/// 
	/// Über Events wird der Fortschritt an den User weitergegeben
	/// </summary>
	public void Run()
	{
		Start?.Invoke();

		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			Progress?.Invoke(i);
		}

		Stop?.Invoke();
	}
}