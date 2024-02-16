using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public partial class SalaryDiagram : Window
	{
		public SalaryDiagram()
		{
			InitializeComponent();

			SeriesCollection = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Зарплата за 2021",
					Values = new ChartValues<double> { 40000, 65000, 5000, 23000 ,45000 }
				},
				new LineSeries
				{
					Title = "Зарплата за 2022",
					Values = new ChartValues<double> { 120000, 70000, 35000, 48900 ,66666 },
					PointGeometry = null
				},
				new LineSeries
				{
					Title = "Зарплата за 2023",
					Values = new ChartValues<double> { 43000,28900,78700,2070,74500 },
					PointGeometry = DefaultGeometries.Square,
					PointGeometrySize = 15
				}
			};

			Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
			YFormatter = value => value.ToString("C");

			SeriesCollection.Add(new LineSeries
			{
				Title = "Series 4",
				Values = new ChartValues<double> { 5, 3, 2, 4 },

				PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
				PointGeometrySize = 50,
				PointForeground = Brushes.Gray
			});

			SeriesCollection[3].Values.Add(5d);

			DataContext = this;
		}

		public SeriesCollection SeriesCollection { get; set; }
		public string[] Labels { get; set; }
		public Func<double, string> YFormatter { get; set; }
	}
}