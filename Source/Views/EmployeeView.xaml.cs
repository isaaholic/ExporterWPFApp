using Source.Models;
using Source.ViewModels;
using System.Windows.Controls;

namespace Source.Views
{
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                if (dataGrid.DataContext is EmployeeViewModel viewModel)
                {
                    foreach (var item in e.AddedItems)
                    {
                        viewModel.SelectedEmployees.Add((Employee)item);
                    }
                    foreach (var item in e.RemovedItems)
                    {
                        viewModel.SelectedEmployees.Remove((Employee)item);
                    }
                }
            }
        }
    }
}
