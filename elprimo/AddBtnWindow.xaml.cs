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
using System.Windows.Shapes;

namespace elprimo
{
    /// <summary>
    /// Логика взаимодействия для AddBtnWindow.xaml
    /// </summary>
    public partial class AddBtnWindow : Window
    {
        proektEntities context;

        public AddBtnWindow(proektEntities context, ClientService ClientService)
        {
            InitializeComponent();
            this.context = context;
            CmbClient.ItemsSource = context.Clients.ToList();
            CmbService.ItemsSource = context.Services.ToList();
            this.DataContext = ClientService;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
