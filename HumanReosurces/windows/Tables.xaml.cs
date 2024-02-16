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
using HumanReosurces.diagrams;
using HumanReosurces.windows;

namespace HumanReosurces.windows
{
	public partial class Tables : Window
	{
		public static CandidatesWindow candidatesWindow;
		public static CareerGrowthWindow careerGrowth;
		public static CompensationWindow compensationWindow;
		public static EmployeeWindow employeeWindow;
		public static SalaryDiagram salaryDiagram;
		public static BenefitsDiagram benefitsDiagram;
		public static DepartmentWorkload departmentWorkload;
		public Tables()
		{
			InitializeComponent();
		}

		private void OpenCandidates(object sender, RoutedEventArgs e)
		{
			if (candidatesWindow == null || !candidatesWindow.IsVisible)
			{
				candidatesWindow = new CandidatesWindow();
				candidatesWindow.Closed += (s, args) => candidatesWindow = null;
				candidatesWindow.Show();
			}
			else candidatesWindow.Focus();
        }

		private void OpenCareer(object sender, RoutedEventArgs e)
		{
			if (careerGrowth == null || !careerGrowth.IsVisible)
			{
				careerGrowth = new CareerGrowthWindow();
				careerGrowth.Closed += (s, args) => careerGrowth = null;
				careerGrowth.Show();
			}
			else careerGrowth.Focus();
		}

		private void OpenCompensation(object sender, RoutedEventArgs e)
		{
			if (compensationWindow == null || !compensationWindow.IsVisible)
			{
				compensationWindow = new CompensationWindow();
				compensationWindow.Closed += (s, args) => compensationWindow = null;
				compensationWindow.Show();
			}
			else compensationWindow.Focus();
		}

		private void OpenEmployee(object sender, RoutedEventArgs e)
		{
			if (employeeWindow == null || !employeeWindow.IsVisible)
			{
				employeeWindow = new EmployeeWindow();
				employeeWindow.Closed += (s, args) => employeeWindow = null;
				employeeWindow.Show();
			}
			else employeeWindow.Focus();
		}
		private void OpenSalaryDiagram(object sender, RoutedEventArgs e)
		{
			if (salaryDiagram == null || !salaryDiagram.IsVisible)
			{
				salaryDiagram = new SalaryDiagram();
				salaryDiagram.Closed += (s, args) => salaryDiagram = null;
				salaryDiagram.Show();
			}
			else salaryDiagram.Focus();
		}

		private void OpenBenefitsDiagram(object sender, RoutedEventArgs e)
		{
			if (benefitsDiagram == null || !benefitsDiagram.IsVisible)
			{
				benefitsDiagram = new BenefitsDiagram();
				benefitsDiagram.Closed += (s, args) => benefitsDiagram = null;
				benefitsDiagram.Show();
			}
			else benefitsDiagram.Focus();
        }

		private void OpenDepartmentWorkload(object sender, RoutedEventArgs e)
		{
			if (departmentWorkload == null || !departmentWorkload.IsVisible)
			{
				departmentWorkload = new DepartmentWorkload();
				departmentWorkload.Closed += (s, args) => departmentWorkload = null;
				departmentWorkload.Show();
			}
			else departmentWorkload.Focus();
		}
	}
}
