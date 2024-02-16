using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HumanReosurces.windows;

namespace HumanReosurces.windows
{
	public partial class Authorization : Window
	{
		public static Tables tables;
		public Authorization()
		{
			InitializeComponent();
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
