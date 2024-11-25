using System.ComponentModel;
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

namespace ListView_20
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool isSorted = false;
		public MainWindow()
		{
			InitializeComponent();
			List<User> listUser = new List<User>
			{
				new User() { Name = "le khai duong", Age = 21, Mail = "DuongLKHE173232@fpt.edu.vn", Sex=sexType.Male },
				new User() { Name = "Nguyen Thu Phuong", Age = 20, Mail = "PhuongNT173317@fpt.edu.vn", Sex=sexType.Female },
				new User() { Name = "Pham Bui Chau Nam", Age = 21, Mail = "NamPBC173299@fpt.edu.vn", Sex=sexType.Male },
				new User() { Name = "Ngo Quy Tien", Age = 17, Mail = "TienNQ174372@fpt.edu.vn", Sex=sexType.Male },
				new User() { Name = "Le Thi Dieu Linh", Age = 28, Mail = "LinhLTD173214@fpt.edu.vn", Sex=sexType.Female }
			};
			lvUser.ItemsSource = listUser;

			CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUser.ItemsSource);
			//PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
			//view.GroupDescriptions.Add(groupDescription);

			//view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

			view.Filter = UserFilter;
		}

		private bool UserFilter(object item)
		{
			if (string.IsNullOrEmpty(txtFilter.Text))
			{
				return true;
			}
			else
			{
				return ((item as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			}
		}
		private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader? header = sender as GridViewColumnHeader;
			CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUser.ItemsSource);
			if (isSorted)
			{
				//view.SortDescriptions.Remove(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
				view.SortDescriptions.Clear();
				view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
			}
			else
			{
				//view.SortDescriptions.Remove(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
				view.SortDescriptions.Clear();
				view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
			}

			isSorted = !isSorted;
		}

		private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CollectionViewSource.GetDefaultView(lvUser.ItemsSource).Refresh();
		}
	}
	public enum sexType
	{
		Male, Female
	};
	public class User
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Mail { get; set; }

		public sexType Sex { get; set; }
	}
}