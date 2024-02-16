using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using HumanReosurces.windows;

namespace HumanReosurces
{
	public partial class MainWindow : Window
	{
		private string ImagePath;
		public static windows.Authorization authorization;
		public static Tables tables;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void LoadImage(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Загрузки (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";

			if (fileDialog.ShowDialog() == true)
			{
				try
				{
					ImagePath = fileDialog.FileName;
					BitmapImage bitmapImage = new BitmapImage(new Uri(ImagePath));
					PeopleFace.Source = bitmapImage;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка загрузки изображения {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void HaveAccount(object sender, MouseButtonEventArgs e)
		{
			if (authorization == null || !authorization.IsVisible)
			{
				authorization = new windows.Authorization();
				authorization.Closed += (s, args) => authorization = null;
				authorization.Show();
			}
			else authorization.Focus();
		}

		private void GoToTables(object sender, RoutedEventArgs e)
		{
			if (tables == null || !tables.IsVisible)
			{
				tables = new Tables();
				tables.Closed += (s, args) => tables = null;
				tables.Show();
			}
			else tables.Focus();
		}
	}
}