using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
	public partial class CandidatesWindow : Window
	{
		HumanResourcesEntities candidates = new HumanResourcesEntities();

		private List<Candidate> candidatesList;

		public CandidatesWindow()
		{
			InitializeComponent();
			candidatesList = candidates.Candidates.ToList();
			CandidatesInfo.ItemsSource = candidatesList;
		}

		private void InsertData(object sender, RoutedEventArgs e)
		{
			Candidate candidate = new Candidate();
			candidate.Surname = txtSurname.Text;
			candidate.Name = txtName.Text;
			candidate.Patronymic = txtPatronymic.Text;
			candidate.Contact_info = txtContact.Text;

			if (DateTime.TryParse(txtInterview.Text, out DateTime interview)) candidate.Interview_date = interview;
			else
			{
				MessageBox.Show("Дата введена неверно!");
				return;
			}

			candidate.Resume = txtResume.Text;
			candidate.Status = txtStatus.Text;

			try
			{
				candidates.Candidates.Add(candidate);
				candidates.SaveChanges();
				CandidatesInfo.ItemsSource = candidates.Candidates.ToList();
			}
			catch (DbEntityValidationException ex)
			{
				foreach (var entityValidationError in ex.EntityValidationErrors)
				{
					foreach (var validationError in entityValidationError.ValidationErrors)
					{
						MessageBox.Show($"Проблема валидации: {validationError.PropertyName} - {validationError.ErrorMessage}");
					}
				}
			}
		}

		private void UpdateData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var updateRow = candidates.Candidates.Where(w => w.Id_candidate == num).FirstOrDefault();

			if (updateRow != null)
			{
				updateRow.Surname = txtSurname.Text;
				updateRow.Name = txtName.Text;
				updateRow.Patronymic = txtPatronymic.Text;
				updateRow.Contact_info = txtContact.Text;
				updateRow.Resume = txtResume.Text;

				if (DateTime.TryParse(txtInterview.Text, out DateTime interview)) updateRow.Interview_date = interview;
				else
				{
					MessageBox.Show("Дата введена неверно!");
					return;
				}
				updateRow.Status = txtStatus.Text;

				try
				{
					candidates.SaveChanges();
					CandidatesInfo.ItemsSource = candidates.Candidates.ToList();
				}
				catch(DbEntityValidationException ex)
				{
					foreach(var entityValidationError in ex.EntityValidationErrors)
					{
						foreach(var ValidationError in entityValidationError.ValidationErrors)
						{
							MessageBox.Show($"Проблема валидации: {ValidationError.PropertyName} - {ValidationError.ErrorMessage}");
						}
					}
				}
			}
		}

		private void DeleteData(object sender, RoutedEventArgs e)
		{
			int num = Convert.ToInt32(txtID.Text);
			var deleteRow = candidates.Candidates.Where(w => w.Id_candidate == num).FirstOrDefault();
			candidates.Candidates.Remove(deleteRow);
			candidates.SaveChanges();
			CandidatesInfo.ItemsSource = candidates.Candidates.ToList();
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

			List<Candidate> searchData = candidatesList.AsEnumerable().Where(item =>
			{
				switch (selectedSearchCategory)
				{
					case "ID":
						return item.Id_candidate.ToString().Contains(searchText);
					case "Фамилия":
						return item.Surname.ToLower().Contains(searchText);
					case "Имя":
						return item.Name.ToLower().Contains(searchText);
					case "Отчество":
						return item.Patronymic.ToLower().Contains(searchText);
					case "Контактная информация":
						return item.Contact_info.ToLower().Contains(searchText);
					default:
						return false;
				}
			}).ToList();

			CandidatesInfo.ItemsSource = searchData;
		}

		private void ClearDataGrid(object sender, RoutedEventArgs e)
		{
			CandidatesInfo.ItemsSource = candidatesList;
		}
	}
}