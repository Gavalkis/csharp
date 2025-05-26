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
    /// Логика взаимодействия для AddEditPartnerPage.xaml
    /// </summary>
    public partial class AddEditPartnerPage : Page
    {
        private Partner _currentPartner = new Partner();
        public Partner Partner
        {
            get => _currentPartner;
            set => _currentPartner = value;
        }
        public List<PartnerType> PartnerTypes { get; set; }
        //ПОВТОРИТЬ
        public AddEditPartnerPage(Partner selectedPartner)
        {
            InitializeComponent();
            PartnerTypes = masterAndFloorEntities.GetContext().PartnerTypes.ToList();
            CBPartnerTypes.ItemsSource = PartnerTypes;

            if (selectedPartner != null)
            {
                _currentPartner = selectedPartner;
            }
            DataContext = this;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Вы уверены, что хотите удалить данного партнера: {_currentPartner.Title}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    masterAndFloorEntities.GetContext().Partners.Remove(_currentPartner);
                    masterAndFloorEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    NavigationClass.MainFrame.Navigate(new PartnersPage());
                    }catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPartner.PartnerID == 0)
            {
                masterAndFloorEntities.GetContext().Partners.Add(_currentPartner);
            }

            try
            {
                masterAndFloorEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные добавлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
