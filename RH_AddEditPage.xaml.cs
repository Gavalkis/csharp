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
    /// Логика взаимодействия для RH_AddEditPage.xaml
    /// </summary>
    public partial class RH_AddEditPage : Page
    {
        private PartnerProduct _currentPartnerProduct = new PartnerProduct();
        public RH_AddEditPage(PartnerProduct selectedPartnerProduct)
        {
            InitializeComponent();
            if (selectedPartnerProduct != null)
                _currentPartnerProduct = selectedPartnerProduct;
            DataContext = _currentPartnerProduct;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err = new StringBuilder();

            if (PartnerProductsID.Text == string.Empty)
                err.AppendLine("Нет ID");
            if (ProductID.Text == string.Empty)
                err.AppendLine("Укажите ProductID");
            if (PartnerID.Text == string.Empty)
                err.AppendLine("Укажите PartnerID");
            if (Quantity.Text == string.Empty)
                err.AppendLine("Укажите Quantity");
            if (Date.Text == string.Empty || Date.SelectedDate == null)
                err.AppendLine("Укажите Date");
            
            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }
            if (_currentPartnerProduct.PartnerProductsID == 0)
                masterAndFloorEntities1.GetContext().PartnerProducts.Add(_currentPartnerProduct);

            try
            {
                masterAndFloorEntities1.GetContext().SaveChanges();
                MessageBox.Show("Инфа сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
