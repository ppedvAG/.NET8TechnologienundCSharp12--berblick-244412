namespace MauiAppDemo;

public partial class MainPage : ContentPage
{
	int count = 0;

	/// <summary>
	/// InitializeComponent: Baut die GUI auf
	/// </summary>
	public MainPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Über das Name Attribut (x:Name) können UI Elemente aus dem Frontend im Backend angreifbar gemacht werden
	/// Über Events kommunizieren Backend und Frontend miteinander
	/// </summary>
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}
