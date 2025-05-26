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

namespace masterAndFloorApp
{
    /// <summary>
    /// Логика взаимодействия для MaterialCalculatorPage.xaml
    /// </summary>
    public partial class MaterialCalculatorPage : Page
    {
        public MaterialCalculatorPage()
        {
            InitializeComponent();
            ProductTypeComboBox.ItemsSource = masterAndFloorEntities1.GetContext().ProductTypes.ToList();
            MaterialTypeComboBox.ItemsSource = masterAndFloorEntities1.GetContext().MaterialTypes.ToList();
        }

        public static int CalculateRequiredMaterial(int productQuantity, double coefficient, double defectRate)
        {
            if (productQuantity <= 0 || coefficient <= 0 || defectRate < 0)
                return -1;

            double total = productQuantity * coefficient;
            double withDefect = total * (1 + defectRate / 100.0);

            return (int)Math.Ceiling(withDefect);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Введите корректное количество продукции.");
                    return;
                }

                if (!double.TryParse(CoefficientTextBox.Text, out double coefficient) || coefficient <= 0)
                {
                    MessageBox.Show("Введите корректный коэффициент.");
                    return;
                }

                if (!double.TryParse(DefectRateTextBox.Text, out double defectRate) || defectRate < 0)
                {
                    MessageBox.Show("Введите корректный процент брака.");
                    return;
                }

                int requiredMaterial = CalculateRequiredMaterial(quantity, coefficient, defectRate);

                if (requiredMaterial == -1)
                {
                    ResultTextBlock.Text = "Ошибка в расчёте.";
                }
                else
                {
                    ResultTextBlock.Text = $"Необходимое количество материала: {requiredMaterial}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ProductTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductTypeComboBox.SelectedItem is ProductType selected)
            {
                CoefficientTextBox.Text = selected.Ratio.ToString("F3");
            }
        }

        private void MaterialTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MaterialTypeComboBox.SelectedItem is MaterialType selected && selected.DefectRate.HasValue)
            {
                DefectRateTextBox.Text = selected.DefectRate.Value.ToString("F3");
            }
        }
    }
}
