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
using HumanReosurces.windows;
using System.Globalization;

namespace HumanReosurces.windows
{
	
	public partial class EmployeeWindow : Window
	{
		HumanResourcesEntities employees = new HumanResourcesEntities();

		private List<Employee> employeesList;
		public EmployeeWindow()
		{
			InitializeComponent();
			employeesList = employees.Employees.ToList();
			EmployeeInfo.ItemsSource = employeesList;
		}

		private void InsertData(object sender, RoutedEventArgs e)
		{
			Employee employee = new Employee();
			employee.Surname = txtSurname.Text;
			employee.Name = txtName.Text;
			employee.Patronymic = txtPatronymic.Text;
			employee.Position = txtPosition.Text;

			if (DateTime.TryParse(txtHire.Text, out DateTime hireDate)) employee.Hire_date = hireDate;
			else
			{
				MessageBox.Show("Дата введена неверно!");
				return;
			}

			employees.Employees.Add(employee);
			employees.SaveChanges();
			EmployeeInfo.ItemsSource = employees.Employees.ToList();
        }

		private void UpdateData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var updateRow = employees.Employees.Where(w => w.Id_employee == num).FirstOrDefault();

			if (updateRow != null)
			{
				updateRow.Surname = txtSurname.Text;
				updateRow.Name = txtName.Text;
				updateRow.Patronymic = txtPatronymic.Text;
				updateRow.Position = txtPosition.Text;

				if (DateTime.TryParse(txtHire.Text, out DateTime hireDate)) updateRow.Hire_date = hireDate;
				else
				{
					MessageBox.Show("Дата введена неверно!");
					return;
				}

				employees.SaveChanges();
				EmployeeInfo.ItemsSource = employees.Employees.ToList();
			}
		}

		private void DeleteData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var deleteRow = employees.Employees.Where(w => w.Id_employee == num).FirstOrDefault();

			if(deleteRow != null)
			{
				employees.Employees.Remove(deleteRow);
				employees.SaveChanges();
				EmployeeInfo.ItemsSource = employees.Employees.ToList();
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

			List<Employee> searchData = employeesList.AsEnumerable().Where(item =>
			{
				switch (selectedSearchCategory)
				{
					case "ID":
						return item.Id_employee.ToString().ToLower().Contains(searchText);
					case "Фамилия":
						return item.Surname.ToString().ToLower().Contains(searchText);
					case "Имя":
						return item.Name.ToString().ToLower().Contains(searchText);
					case "Отчество":
						return item.Patronymic.ToString().ToLower().Contains(searchText);
					case "Должность":
						return item.Position.ToString().ToLower().Contains(searchText);
					case "Дата приёма":
						return item.Hire_date.HasValue && item.Hire_date.Value.ToString("yyyy-MM-dd").ToLower().Contains(searchText);
					default: 
						return false;
				}
			}).ToList();

			EmployeeInfo.ItemsSource = searchData;
        }

		private void ClearDataGrid(object sender, RoutedEventArgs e)
		{
			EmployeeInfo.ItemsSource = employeesList;
		}
	}
}
