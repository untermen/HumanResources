using LiveCharts;
using LiveCharts.Defaults;
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
	public partial class BenefitsDiagram : Window
	{
		public BenefitsDiagram()
		{
			InitializeComponent();

			var r = new Random();
			ValuesA = new ChartValues<ObservablePoint>();
			ValuesB = new ChartValues<ObservablePoint>();
			ValuesC = new ChartValues<ObservablePoint>();

			for (var i = 0; i < 50; i++)
			{
				ValuesA.Add(new ObservablePoint(r.NextDouble() * 100, r.NextDouble() * 100));
				ValuesB.Add(new ObservablePoint(r.NextDouble() * 100, r.NextDouble() * 100));
				ValuesC.Add(new ObservablePoint(r.NextDouble() * 100, r.NextDouble() * 100));
			}

			DataContext = this;
		}

		public ChartValues<ObservablePoint> ValuesA { get; set; }
		public ChartValues<ObservablePoint> ValuesB { get; set; }
		public ChartValues<ObservablePoint> ValuesC { get; set; }

		private void RandomizeOnClick(object sender, RoutedEventArgs e)
		{
			var r = new Random();
			for (var i = 0; i < 50; i++)
			{
				double xOffset = (r.NextDouble() - 0.5) * 10;
				double yOffset = (r.NextDouble() + 0.5) * 10;


				ValuesA[i].X = xOffset;
				ValuesA[i].Y = yOffset;

				ValuesB[i].X = xOffset;
				ValuesB[i].Y = yOffset;

				ValuesC[i].X = xOffset;
				ValuesC[i].Y = yOffset;
			}
		}
	}
}