using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using Source.Commands;
using Source.Models;
using Source.Services;
using Source.ViewModels.Common;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Source.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        private readonly IEmployeeService _employeeService;
        public ICommand ExportToTxtCommand { get; set; }
        public ICommand ExportToCsvCommand { get; set; }

        public EmployeeViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            LoadData();
            ExportToTxtCommand = new RelayCommand(() => ExportToTxtMethod(), () => true);
            ExportToCsvCommand = new RelayCommand(() => ExportToCsvMethod(), () => true);
        }

        private void ExportToCsvMethod()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            StringBuilder sb = new StringBuilder();
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
                config.Delimiter = ";";

                using (CsvWriter csv = new CsvWriter(new StringWriter(sb),config))
                {
                    csv.WriteRecords(_selectedEmployees);
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }

        private void ExportToTxtMethod()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("#Id - Name - Age");
                foreach (var item in _selectedEmployees)
                {
                    sb.AppendLine($"#{item.Id} - {item.Name} - {item.Age}");
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }

        private IList<Employee> _selectedEmployees = new List<Employee>();
        public IList<Employee> SelectedEmployees
        {
            get { return _selectedEmployees; }
            set
            {
                _selectedEmployees = value;
                OnPropertyChanged(nameof(SelectedEmployees));
            }
        }

        private List<Employee> employeesList;
        public List<Employee> EmployeesList
        {
            get { return employeesList; }
            set
            {
                employeesList = value;
                OnPropertyChanged(nameof(EmployeesList));
            }
        }

        private void LoadData()
        {
            EmployeesList = _employeeService.GetEmployees();
        }
    }
}
