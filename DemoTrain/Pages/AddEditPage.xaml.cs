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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>

    public partial class AddEditPage : Page
    {
        private Partner _currentPartner = new Partner();
        public Partner Partner
        {
            get => _currentPartner;
            set => _currentPartner = value;
        }

        public List<PartnerType> PartnerTypes { get; set; } // Изменено на свойство

        public AddEditPage(Partner selectedPartner)
        {
            InitializeComponent();

            // Загрузка типов партнеров
            PartnerTypes = masterAndFloorEntities1.GetContext().PartnerTypes.ToList();

            if (selectedPartner != null)
            {
                _currentPartner = selectedPartner;
            }

            DataContext = this; // Устанавливаем DataContext для всей страницы
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err = new StringBuilder();
            if (CBPartnerTypes.SelectedValue == null)
            {
                err.AppendLine("Выберете тип партнера");
            }
            if (string.IsNullOrWhiteSpace(_currentPartner.Title))
                err.AppendLine("Укажите наименование");
            if (string.IsNullOrWhiteSpace(_currentPartner.Director))
                err.AppendLine("Укажите ФИО Директора");
            if (string.IsNullOrWhiteSpace(_currentPartner.Email))
                err.AppendLine("Укажите Эл. почту");
            if (string.IsNullOrWhiteSpace(_currentPartner.Phone))
                err.AppendLine("Укажите Телефон");
            if (string.IsNullOrWhiteSpace(_currentPartner.LegalAddress))
                err.AppendLine("Укажите Юр адрес");
            if (string.IsNullOrWhiteSpace(_currentPartner.INN))
                err.AppendLine("Укажите ИНН");
            if (string.IsNullOrWhiteSpace(_currentPartner.Rating.ToString()))
                err.AppendLine("Укажите Рейтинг");
            if (_currentPartner.Rating % 1 != 0)
                err.AppendLine("Укажите целое значение рейтинга");
            if (_currentPartner.Rating < 0)
                err.AppendLine("Укажите не отрицательное  значение рейтинга");

            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }

            if (_currentPartner.PartnerID == 0)
                masterAndFloorEntities1.GetContext().Partners.Add(_currentPartner);

            try
            {
                masterAndFloorEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Окно выбора да/нет
            if (MessageBox.Show($"Вы уверены, что хотите удалить данного партнера: {_currentPartner.Title}?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Если да, то выполняется попытка удаления данных
                try
                {
                    masterAndFloorEntities1.GetContext().Partners.Remove(_currentPartner);
                    masterAndFloorEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                    NavigationClass.MainFrame.Navigate(new PartnersPage());
                }
                //Иначе выводит ошибку
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
    }

}
