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
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        

        public PartnersPage()
        {
            InitializeComponent();
            PartnersItemsControl.ItemsSource = masterAndFloorEntities1.GetContext().Partners.ToList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender as Border != null)
            {
                NavigationService.Navigate(new AddEditPage((sender as Border).DataContext as Partner));
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Partner));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                CalculateDiscounts();
                masterAndFloorEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                PartnersItemsControl.ItemsSource = masterAndFloorEntities1.GetContext().Partners.ToList();
            }   
        }

        public void CalculateDiscounts()
        {
            //Явно получаем данные о партнерах
            var partners = masterAndFloorEntities1.GetContext().Partners.Include("PartnerProducts").ToList();

            foreach (var partner in partners)
            {
                //Складываем количество проданной продукции определенного партнера
                long totalQuantity = partner.PartnerProducts.Sum(pp => pp.Quantity);
                // Устанавливаем значение Discount
                if (totalQuantity < 10000)
                    partner.Discount = 0f; // 0% скидка
                else if (totalQuantity < 50000)
                    partner.Discount = 5f; // 5% скидка
                else if (totalQuantity < 300000)
                    partner.Discount = 10f; // 10% скидка
                else
                    partner.Discount = 15f; // 15% скидка
            }
            try
            {
                masterAndFloorEntities1.GetContext().SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        

    }
}
