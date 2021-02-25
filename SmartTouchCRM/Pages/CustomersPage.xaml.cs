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
    /// Logika interakcji dla klasy CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        readonly CustomersService CustomerService = new CustomersService();

        public CustomersPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Customers_Data.ItemsSource = CustomerService.GetList();

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

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            CustomersWindow_Add addWindow = new CustomersWindow_Add();
            addWindow.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            SmartTouchDatabseEntities _reload = new SmartTouchDatabseEntities(); // mało efektywne ale musi tak być, przez problemy z odświeżaniem
            Customers_Data.ItemsSource = _reload.Customers.ToList();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            Customers selectedCustomer = (Customers_Data.SelectedItem as Customers);
            if (selectedCustomer == null)
            {
                MessageBox.Show("Musisz najpierw wybrać produkt!");
            }
            else
            {

                CustomersWindow_Edit editWindow = new CustomersWindow_Edit(selectedCustomer);
                editWindow.ShowDialog();
                

            }
            Reload();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int selectedCustomerId = (Customers_Data.SelectedItem as Customers).customer_id;
            CustomerService.Remove(selectedCustomerId);
            Reload();
        }
    }
}
