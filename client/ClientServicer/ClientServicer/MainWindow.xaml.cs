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
using ClientServicer.Restoran_serv;

namespace ClientServicer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KitchenServiceClient KSC = new KitchenServiceClient();
        List<Dish> listDish = new List<Dish>();

        public MainWindow()
        {
            InitializeComponent();        
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listDish.Clear();
                listDish.AddRange(KSC.getAllDishes());
                LpMain.ItemsSource = listDish;
            }
            catch
            {
                MessageBox.Show("Ошибка соиденения с сервером");
            }

        }
    }
}
