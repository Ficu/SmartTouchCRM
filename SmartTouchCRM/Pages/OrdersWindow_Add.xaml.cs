using SmartTouchCRM.Classes;
using System;
using System.Collections;
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

namespace SmartTouchCRM.Pages
{
    /// <summary>
    /// Interaction logic for OrdersWindow_Add.xaml
    /// </summary>
    public partial class OrdersWindow_Add : Window
    {
        private readonly CustomersService customers = new CustomersService();
        private readonly ProductService products = new ProductService();
        private readonly OrderService orders = new OrderService();

        public OrdersWindow_Add()
        {
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            ClientName.ItemsSource = customers.GetList();
            Product_Data.ItemsSource = products.GetList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Customers select = new Customers();

            if(ClientName.SelectedIndex >= 0)
            {
                select = (Customers)ClientName.SelectedValue;
            } else
            {
                MessageBox.Show("Musisz wybrać klienta", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            List<Products> productsToAdd = new List<Products>();

            IList items = Product_Data.SelectedItems;
            if(items.Count > 0)
            {
                foreach (object item in items)
                {
                    productsToAdd.Add(item as Products);
                }
            }
            else
            {                
                MessageBox.Show("Musisz wybrać przynajmniej jeden produkt", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            orders.AddOrder(select.customer_id, productsToAdd);

            this.Hide();
        }
    }
}
