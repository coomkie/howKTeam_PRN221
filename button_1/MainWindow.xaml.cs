using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace button_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Button btn = new Button();
			btn.Content = "Click here";
			gridBtn.Children.Add(btn);

			//TextBlock txb = new TextBlock();
			//txb.Text = "New button";
			//btn.Content = txb;

			TextBox txb = new TextBox();
			txb.Width = 100;
			txb.Height = 50;
			btn.Content = txb;
		}
	}
}