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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MulticriteriaOptimization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddCriteria_Click(object sender, RoutedEventArgs e)
        {
            float weight = 0;
            
            try
            {
                weight = float.Parse(txtCriteriaWeight.Text.Replace('.', ','));              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid weight!", "Cant add criteria");
                return;
            }

            if (weight >= 0 && weight <= 1)
            {
                if(!String.IsNullOrEmpty(txtCriteriaName.Text) && !String.IsNullOrWhiteSpace(txtCriteriaName.Text))
                {
                    var data = new CriteriaPrototype { Name = txtCriteriaName.Text, Weight = weight.ToString() };
                    dataGridCriteria.Items.Add(data);
                }
                else
                {
                    MessageBox.Show("Invalid name!", "Cant add criteria");
                }
            }
            else
            {
                MessageBox.Show("Invalid weight! It mast be in [0,1] range", "Cant add criteria");
            }

        }
        private void btnDeleteCriteria_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = dataGridCriteria.SelectedItems;
            int itemsCount = selectedItems.Count;

            for (int i = 0; i < itemsCount; i++)
            {
                dataGridCriteria.Items.Remove(selectedItems[0]);
            }
        }
    }

    public class CriteriaPrototype
    {
        public string Name { get; set; }
        public string Weight { get; set; }
    }
}
