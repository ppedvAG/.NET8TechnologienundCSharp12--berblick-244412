namespace WinForms;

public partial class Form1 : Form
{
	private int counter;

	public Form1()
	{
		InitializeComponent();
	}

	/// <summary>
	/// View -> Toolbox (UI Komponenten)
	/// View -> Properties -> Komponente anklicken -> Einstellung vornehmen
	/// Properties -> Events (Blitz)
	/// 
	/// Rechtsklick auf Designer/Form1.cs -> View Code
	/// </summary>
	private void button1_Click(object sender, EventArgs e)
	{
		counter++;
		CounterText.Text = counter.ToString();
	}
}
