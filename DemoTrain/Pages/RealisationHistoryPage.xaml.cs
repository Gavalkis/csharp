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
    /// Логика взаимодействия для RealisationHistoryPage.xaml
    /// </summary>
    public partial class RealisationHistoryPage : Page
    {
        private List<Partner> _partners;
        private List<PartnerProduct> _partnerProducts;
        public RealisationHistoryPage()
        {
            InitializeComponent();
            DGridPartnerProducts.ItemsSource = masterAndFloorEntities1.GetContext().PartnerProducts.ToList();

            _partners = masterAndFloorEntities1.GetContext().Partners.ToList();
            CBPartners.ItemsSource = _partners;

            _partnerProducts = masterAndFloorEntities1.GetContext().PartnerProducts.Include("Product").Include("Partner").ToList();
            DGridPartnerProducts.ItemsSource = _partnerProducts;
        }

        private void FilterHistory()
        {
            var selectedPartner = CBPartners.SelectedItem as Partner;
            DateTime? startDate = DPStartDate.SelectedDate;
            DateTime? endDate = DPEndDate.SelectedDate;

            var filteredProducts = masterAndFloorEntities1.GetContext().PartnerProducts.Include("Product").Include("Partner").AsQueryable();

            if (selectedPartner != null)
            {
                filteredProducts = filteredProducts.Where(pp => pp.PartnerID == selectedPartner.PartnerID);
            }

            // Фильтрация по дате
            if (startDate.HasValue)
            {
                filteredProducts = filteredProducts.Where(pp => pp.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                filteredProducts = filteredProducts.Where(pp => pp.Date <= endDate.Value);
            }

            if(IsFilter.IsChecked == false)
            {
                filteredProducts = masterAndFloorEntities1.GetContext().PartnerProducts.Include("Product").Include("Partner").AsQueryable();
            }

            DGridPartnerProducts.ItemsSource = filteredProducts.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                masterAndFloorEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                _partnerProducts = masterAndFloorEntities1.GetContext().PartnerProducts.Include("Product").Include("Partner").ToList();
                DGridPartnerProducts.ItemsSource = _partnerProducts;
            }
        }

        private void CBPartners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterHistory();
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterHistory();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Список на удаление
            var PartnerProductsForRemove = DGridPartnerProducts.SelectedItems.Cast<PartnerProduct>().ToList();
            if (PartnerProductsForRemove.Count <= 0)
            {
                return;
            }
            //Окно выбора да/нет
            if (MessageBox.Show($"Вы уверены, что хотите удалить следущие {PartnerProductsForRemove.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Если да, то выполняется попытка удаления данных
                try
                {
                    masterAndFloorEntities1.GetContext().PartnerProducts.RemoveRange(PartnerProductsForRemove);
                    masterAndFloorEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                    DGridPartnerProducts.ItemsSource = masterAndFloorEntities1.GetContext().PartnerProducts.ToList();
                }
                //Иначе выводит ошибку
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }


        }

        //Для экза не нужны:
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.MainFrame.Navigate(new RH_AddEditPage((sender as Button).DataContext as PartnerProduct));
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.MainFrame.Navigate(new RH_AddEditPage(null));
        }
    }
}
