using System.IO;
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

namespace TreeView_LazyLoaded_21
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives) trvStructure.Items.Add(CreateTreeItem(drive));
		}

		private void trvStructure_Expanded(object sender, RoutedEventArgs e)
		{
			TreeViewItem item = e.Source as TreeViewItem;
			if ((item.Items.Count == 1) && (item.Items[0] is string))
			{
				item.Items.Clear();
				DirectoryInfo expandedDir = null;
				if(item.Tag is DriveInfo) {
					expandedDir = (item.Tag as DriveInfo).RootDirectory;
				}
				if(item.Tag is DirectoryInfo)
				{
					expandedDir = (item.Tag as DirectoryInfo);

				}
				try
				{
					foreach (DirectoryInfo suDir in expandedDir.GetDirectories())
						item.Items.Add(CreateTreeItem(suDir));
				}
				catch
				{

				}
			}
		}
		private TreeViewItem CreateTreeItem(object o)
		{
			TreeViewItem item = new TreeViewItem();
			item.Header = o.ToString();
			item.Tag = o;
			item.Items.Add("Loading...");
			return item;
		}
	}
}