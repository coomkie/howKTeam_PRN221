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

namespace Combobox_18
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Food> listName;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			listName = new List<Food>()
			{
			new Food(){Name="Pizza", Price="40000"},
			new Food(){Name="Melon", Price="20000"},
			new Food(){Name="Chubby", Price="15000"},
			};
			cbxItemSource.ItemsSource = listName;
			//cbxItemSource.DisplayMemberPath = "Name";
			//cbxItemSource.SelectedValuePath = "Price";
			cbxItemSource.SelectionChanged += CbxItemSource_SelectionChanged;
		}

		private void CbxItemSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MessageBox.Show(cbxItemSource.SelectedValue.ToString());
		}

		public class Food
		{
			public string Name { get; set; }
			public string Price { get; set; }
		}
	}
}