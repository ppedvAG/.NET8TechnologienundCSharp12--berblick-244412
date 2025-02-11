using System.Windows;
using EntityFrameworkDemo.Models;

namespace WpfApp;

public partial class MainWindow : Window
{
	private int counter;

	public MainWindow()
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
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		counter++;
		//CounterText.Text = counter.ToString();
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		NorthwindContext db = new NorthwindContext();
		List<Customer> customers = db.Customers.ToList(); //Alle Daten laden
		Data.ItemsSource = customers;
	}
}