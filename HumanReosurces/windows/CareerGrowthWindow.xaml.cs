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
	public partial class CareerGrowthWindow : Window
	{
		HumanResourcesEntities career = new HumanResourcesEntities();

		private List<CareerGrowth> careerGrowthsList;
		public CareerGrowthWindow()
		{
			InitializeComponent();
			careerGrowthsList = career.CareerGrowths.ToList();
			CareerInfo.ItemsSource = careerGrowthsList;
		}

		private void InsertData(object sender, RoutedEventArgs e)
		{
			CareerGrowth careerGrowth = new CareerGrowth();
			careerGrowth.Id_employee = Convert.ToInt64(txtIDEmployee.Text);

			if (DateTime.TryParse(txtPromotion.Text, out DateTime promotion)) careerGrowth.Promotion_date = promotion;
			else
			{
				MessageBox.Show("Дата введена неверно");
				return;
			}

			careerGrowth.New_position = txtPosition.Text;

			career.CareerGrowths.Add(careerGrowth);
			career.SaveChanges();
			CareerInfo.ItemsSource = career.CareerGrowths.ToList();
        }

		private void UpdateData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var updateRow = career.CareerGrowths.Where(w => w.Id_growth == num).FirstOrDefault();

			if (updateRow != null)
			{
				updateRow.Id_employee=Convert.ToInt64(txtIDEmployee.Text);

				if (DateTime.TryParse(txtPromotion.Text, out DateTime promotion)) updateRow.Promotion_date = promotion;
				else
				{
					MessageBox.Show("Дата введена неверно!");
					return;
				}

				updateRow.New_position = txtPosition.Text;

				career.SaveChanges();
				CareerInfo.ItemsSource = career.CareerGrowths.ToList();
			}
		}

		private void DeleteData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var deleteRow = career.CareerGrowths.Where(w => w.Id_growth == num).FirstOrDefault();

			if(deleteRow != null)
			{
				career.CareerGrowths.Remove(deleteRow);
				career.SaveChanges();
				CareerInfo.ItemsSource = career.CareerGrowths.ToList();
			}
		}

		private void ClearDataGrid(object sender, RoutedEventArgs e)
		{
			CareerInfo.ItemsSource = careerGrowthsList;
        }

		private void SearchData(object sender, RoutedEventArgs e)
		{
			string searchText = SearchText.Text.ToLower();
			string selectedSearchCatergory = (searchComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

			if (string.IsNullOrWhiteSpace(selectedSearchCatergory) || string.IsNullOrEmpty(searchText))
			{
				MessageBox.Show("Выберите категорию и впишите текс!");
				return;
			}

			List<CareerGrowth> searchData = careerGrowthsList.AsEnumerable().Where(item =>
			{
				switch (selectedSearchCatergory)
				{
					case "ID":
						return item.Id_growth.ToString().ToLower().Contains(searchText);
					case "ID сотрудника":
						return item.Id_employee.ToString().ToLower().Contains(searchText);
					case "Дата повышения":
						return item.Promotion_date.ToString("yyyy-MM-dd").ToLower().Contains(searchText);
					case "Новая должность":
						return item.New_position.ToString().ToLower().Contains(searchText);
					default:
						return false;
				}
			}).ToList();

			CareerInfo.ItemsSource = searchData;
		}
	}
}