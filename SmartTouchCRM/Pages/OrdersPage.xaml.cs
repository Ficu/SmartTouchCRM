using SmartTouchCRM.Classes;
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

namespace SmartTouchCRM.Pages
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            Reload();

            this.Loaded += delegate
            {
                Window window = Window.GetWindow(this);
                window.SetBinding(Window.MinHeightProperty, new Binding() { Source = this.MinHeight });
                window.SetBinding(Window.MinWidthProperty, new Binding() { Source = this.MinWidth });
            };
        }



        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/WelcomePage.xaml", UriKind.Relative));
        }

        private void ShowOrder_Click(object sender, RoutedEventArgs e)
        {
            

            Orders selectedProduct = (Orders_Data.SelectedItem as Orders);
            if (selectedProduct == null)
            {
                MessageBox.Show("Musisz najpierw wybrać produkt", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                OrdersWindow_Show showOrder = new OrdersWindow_Show(selectedProduct);
                showOrder.ShowDialog();
            }
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow_Add addOrder = new OrdersWindow_Add();
            addOrder.ShowDialog();
            Reload();

        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {

            if (Orders_Data.SelectedItem == null)
            {
                MessageBox.Show("Musisz najpierw wybrać produkt", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult decision = MessageBox.Show("Czy na pewno chcesz usunąć zamówienie?", "Ostrzeżenie", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (decision == MessageBoxResult.Yes)
                {
                    OrderService order = new OrderService();
                    int selectedProductId = (Orders_Data.SelectedItem as Orders).order_id;
                    order.Remove(selectedProductId);
                    Reload();
                } else
                {
                    return;
                }
            }
        }

        private void Reload()
        {
            SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();
            Orders_Data.ItemsSource = _db.Orders.Include("Customers").ToList();
        }
    }
}
