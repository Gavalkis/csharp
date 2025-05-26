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

namespace masterAndFloorCopy
{
    /// <summary>
    /// Логика взаимодействия для MaterialCalculator.xaml
    /// </summary>
    public partial class MaterialCalculator : Page
    {
        public MaterialCalculator()
        {
            InitializeComponent();
            ProductTypeComboBox.ItemsSource = masterAndFloorEntities.GetContext().ProductTypes.ToList();
            MaterialTypeComboBox.ItemsSource = masterAndFloorEntities.GetContext().MaterialTypes.ToList();
        }

        private int Calculate(int quantity, double coefficient, double defectRate)
        {
            if (quantity <= 0 || coefficient <= 0 || defectRate <= 0)
            {
                return -1;
            }
            var total = quantity * coefficient;
            var withDefect = total / (1-defectRate);
            MessageBox.Show($"{withDefect}");
            return (int)Math.Ceiling(withDefect);
            
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                return;
            }
            if (!double.TryParse(CoefficientTextBox.Text, out double coefficient) || coefficient <= 0)
            {
                return;
            }
            if (!double.TryParse(DefectRateTextBox.Text, out double defectRate) || defectRate <= 0)
            {
                return;
            }

            var result = Calculate(quantity, coefficient, defectRate);
            ResultTextBlock.Text = $"Необходимое количество материала: {result}";

        }

        private void ProductTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductTypeComboBox.SelectedItem is ProductType selected)
                CoefficientTextBox.Text = selected.Ratio.ToString("F3");
        }

        private void MaterialTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MaterialTypeComboBox.SelectedItem is MaterialType selected)
                DefectRateTextBox.Text = selected.DefectRate.Value.ToString("F3");
        }
    }
}
