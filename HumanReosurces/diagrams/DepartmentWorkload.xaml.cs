using LiveCharts.Defaults;
using LiveCharts;
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

namespace HumanReosurces.diagrams
{
	/// <summary>
	/// Interaction logic for DepartmentWorkload.xaml
	/// </summary>
	public partial class DepartmentWorkload : Window
	{
		public DepartmentWorkload()
		{
			InitializeComponent();

			var r = new Random();

			Values = new ChartValues<HeatPoint>
			{
                //X means sales man
                //Y is the day
 
                //"Иванов Иван Иванович"
                new HeatPoint(0, 0, r.Next(0, 10)),
				new HeatPoint(0, 1, r.Next(0, 10)),
				new HeatPoint(0, 2, r.Next(0, 10)),
				new HeatPoint(0, 3, r.Next(0, 10)),
				new HeatPoint(0, 4, r.Next(0, 10)),
				new HeatPoint(0, 5, r.Next(0, 10)),
				new HeatPoint(0, 6, r.Next(0, 10)),
 
                //"Грязнова Александра Ивановна"
                new HeatPoint(1, 0, r.Next(0, 10)),
				new HeatPoint(1, 1, r.Next(0, 10)),
				new HeatPoint(1, 2, r.Next(0, 10)),
				new HeatPoint(1, 3, r.Next(0, 10)),
				new HeatPoint(1, 4, r.Next(0, 10)),
				new HeatPoint(1, 5, r.Next(0, 10)),
				new HeatPoint(1, 6, r.Next(0, 10)),
 
                //"Луковников Пётр Петрович"
                new HeatPoint(2, 0, r.Next(0, 10)),
				new HeatPoint(2, 1, r.Next(0, 10)),
				new HeatPoint(2, 2, r.Next(0, 10)),
				new HeatPoint(2, 3, r.Next(0, 10)),
				new HeatPoint(2, 4, r.Next(0, 10)),
				new HeatPoint(2, 5, r.Next(0, 10)),
				new HeatPoint(2, 6, r.Next(0, 10)),
			};

			Days = new[]
			{
				"Понедельник",
				"Вторник",
				"Среда",
				"Четверг",
				"Пятница",
				"Суббота",
				"Воскресенье"
			};

			SalesMan = new[]
			{
				"Иванов Иван Иванович",
				"Грязнова Александра Ивановна",
				"Луковников Пётр Петрович"
			};

			DataContext = this;
		}

		public ChartValues<HeatPoint> Values { get; set; }
		public string[] Days { get; set; }
		public string[] SalesMan { get; set; }

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			var r = new Random();
			foreach (var chartValue in Values)
			{
				chartValue.Weight = r.Next(0, 10);
			}
		}
	}
}