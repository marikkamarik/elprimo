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

namespace elprimo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       proektEntities context;

        public MainWindow()
        {
            InitializeComponent();
            context = new proektEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridWork.ItemsSource = context.ClientServices.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new ClientService();
            context.ClientServices.Add(NewClientService);
            var AddBtnWindow = new AddBtnWindow(context, NewClientService);
            AddBtnWindow.ShowDialog();
            //апрар

        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentRental = DataGridWork.SelectedItem as ClientService;
            if (currentRental == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientServices.Remove(currentRental);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
