using System.Windows;
using System.Windows.Media;

namespace DelegateWPF;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Self.Background = new SolidColorBrush(Colors.LightGreen);
	}

	private void Self_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
	{
		Self.Background = new SolidColorBrush(Colors.Aqua);
	}

	private void Self_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
	{
		Self.Background = new SolidColorBrush(Colors.White);
	}
}