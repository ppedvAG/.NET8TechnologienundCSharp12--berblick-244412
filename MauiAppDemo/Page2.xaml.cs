using System.Collections.ObjectModel;

namespace MauiAppDemo;

public partial class Page2 : ContentPage
{
	private double sliderValue;

	public double SliderValue { get => sliderValue; set => sliderValue = value; }

	public ObservableCollection<int> Zahlen { get; set; } //Wird verwendet, um die GUI zu benachrichtigen über Änderungen in der Liste selbst

	public Page2()
	{
		Zahlen = new ObservableCollection<int>(Enumerable.Range(0, 20));
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Textfeld.FontSize += 5;
		Textfeld.Text = $"Hallo {string.Join(',', MehrereNamen.Text)}";

		Zahlen.RemoveAt(Random.Shared.Next(0, Zahlen.Count));
	}

	private void Eingabefeld_TextChanged(object sender, TextChangedEventArgs e)
	{
		Textfeld.Text = $"Hallo {Eingabefeld.Text}";
	}

	private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
	{
		SearchBar b = (SearchBar) sender;
		//...
	}

	//private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
	//{
	//	StepperValue.Text = (sender as Stepper).Value.ToString();
	//}
}