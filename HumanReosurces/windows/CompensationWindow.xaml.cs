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
using HumanReosurces.models;

namespace HumanReosurces.windows
{
	public partial class CompensationWindow : Window
	{
		HumanResourcesEntities compensations = new HumanResourcesEntities();

		private List<Compensation> compensationsList;

		public CompensationWindow()
		{
			InitializeComponent();
			compensationsList = compensations.Compensations.ToList();
			CompensationInfo.ItemsSource = compensationsList;
		}

		private void InsertData(object sender, RoutedEventArgs e)
		{
			Compensation compensation = new Compensation();
			compensation.Id_employee = Convert.ToInt64(txtIDEmployee.Text);
			compensation.Salary = Convert.ToDecimal(txtIDEmployee.Text);
			compensation.Benefits = txtBenefits.Text;

			compensations.Compensations.Add(compensation);
			compensations.SaveChanges();
			CompensationInfo.ItemsSource = compensations.Compensations.ToList();
        }

		private void UpdateData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtIDEmployee.Text);
			var updateRow = compensations.Compensations.Where(w => w.Id_compensation == num).FirstOrDefault();

			if (updateRow != null)
			{
				updateRow.Id_employee = Convert.ToInt64(txtIDEmployee.Text);
				updateRow.Salary = Convert.ToDecimal(txtSalary.Text);
				updateRow.Benefits = txtBenefits.Text;

				compensations.SaveChanges();
				CompensationInfo.ItemsSource = compensations.Compensations.ToList();
			}
		}

		private void DeleteData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var deleteRow = compensations.Compensations.Where(w => w.Id_compensation == num).FirstOrDefault();

			if(deleteRow != null)
			{
				compensations.Compensations.Remove(deleteRow);
				compensations.SaveChanges();
				CompensationInfo.ItemsSource = compensations.Compensations.ToList();
			}
		}

		private void SearchData(object sender, RoutedEventArgs e)
		{
			string searchText = SearchText.Text.ToLower();
			string selectedSearchCategory = (searchComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

			if (string.IsNullOrWhiteSpace(selectedSearchCategory) || string.IsNullOrEmpty(searchText))
			{
				MessageBox.Show("Выберите категорию и впишите текст!");
				return;
			}

			List<Compensation> searchData = compensationsList.AsEnumerable().Where(item =>
			{
				switch (selectedSearchCategory)
				{
					case "ID":
						return item.Id_compensation.ToString().ToLower().Contains(searchText);
					case "ID сотрудника":
						return item.Id_employee.ToString().ToLower().Contains(searchText);
					case "Зарплата":
						return item.Salary.ToString().ToLower().Contains(searchText);
					case "Надбавки":
						return item.Benefits.ToString().ToLower().Contains(searchText);
					default:
						return false;
				}
			}).ToList();

			CompensationInfo.ItemsSource = searchData;
		}

		private void ClearDataGrid(object sender, RoutedEventArgs e)
		{
			CompensationInfo.ItemsSource = compensationsList;
		}
	}
}