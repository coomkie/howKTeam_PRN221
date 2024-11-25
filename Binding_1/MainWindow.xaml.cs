using System.ComponentModel;
using System.Windows;


namespace Binding_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private string buttonName;

		public string ButtonName
		{
			get { return buttonName; } set
			{
				buttonName = value;
				OnPropertyChanged("ButtonName");
			}
		}
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
			ButtonName = "Binding datafrom code behind";
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}