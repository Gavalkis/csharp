using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    /// Логика взаимодействия для RealisationHistory.xaml
    /// </summary>
    public partial class RealisationHistory : Page
    {
        public RealisationHistory()
        {
            InitializeComponent();
            CBPartners.ItemsSource = masterAndFloorEntities.GetContext().Partners.ToList();
            DGridPartnerProducts.ItemsSource = masterAndFloorEntities.GetContext().PartnerProducts.ToList();
        }

        public void FilterHistory()
        {
            var selectedPartner = CBPartners.SelectedItem as Partner;
            
            DateTime? startDate = DPStartDate.SelectedDate;
            DateTime? endDate = DPEndDate.SelectedDate;

            var requiredPartnerProducts = masterAndFloorEntities.GetContext().PartnerProducts.AsQueryable();

            if(selectedPartner != null)
            {
                requiredPartnerProducts = requiredPartnerProducts.Where(p => p.PartnerID == selectedPartner.PartnerID);
            }
            if (startDate.HasValue)
            {
                requiredPartnerProducts = requiredPartnerProducts.Where(p => p.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                requiredPartnerProducts = requiredPartnerProducts.Where(p => p.Date <= endDate.Value);
            }
            if(IsFilter.IsChecked == false)
            {
                requiredPartnerProducts = masterAndFloorEntities.GetContext().PartnerProducts.AsQueryable();
            }
            DGridPartnerProducts.ItemsSource = requiredPartnerProducts.ToList();
        }

        private void CBPartners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterHistory();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterHistory();
        }

        private void IsFilter_Click(object sender, RoutedEventArgs e)
        {
            DGridPartnerProducts.ItemsSource = masterAndFloorEntities.GetContext().PartnerProducts.AsQueryable().ToList();
        }
    }
}
