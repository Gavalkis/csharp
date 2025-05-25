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
                var partnerService = new PartnerService();
                partnerService.CalculateDiscounts();

                masterAndFloorEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                PartnersItemsControl.ItemsSource = masterAndFloorEntities1.GetContext().Partners.ToList();
            }   
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            if (border != null)
            {
                // Получаем данные о партнере из DataContext
                var partner = border.DataContext as Partner; // Замените Partner на ваш класс модели

                // Переход на страницу AddEdit с передачей данных о партнере
                var addEditPage = new AddEditPage(partner); // Предполагается, что у вас есть конструктор, принимающий партнера
                NavigationService.Navigate(addEditPage);
            }
        }

    }
}
