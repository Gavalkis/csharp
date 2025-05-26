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
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            InitializeComponent();
            PartnersIC.ItemsSource = masterAndFloorEntities.GetContext().Partners.ToList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender as Border != null)
            {
                NavigationClass.MainFrame.Navigate(new AddEditPartnerPage((sender as Border).DataContext as Partner));
            }

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.MainFrame.Navigate(new AddEditPartnerPage(null));
        }
        
        public static void CalculateDiscount()
        {
            var partners = masterAndFloorEntities.GetContext().Partners.ToList();
            foreach(var partner in partners)
            {
                var total = partner.PartnerProducts.Sum(pp => pp.Quantity);
                if (total < 10000)
                    partner.Discount = 0f;
                else if (total < 50000)
                    partner.Discount = 5f;
                else if (total < 300000)
                    partner.Discount = 10f;
                else
                    partner.Discount = 15f;
            }
            masterAndFloorEntities.GetContext().SaveChanges();
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible) 
            {
                CalculateDiscount();
                masterAndFloorEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                PartnersIC.ItemsSource = masterAndFloorEntities.GetContext().Partners.ToList();
            }
        }
    }
}
