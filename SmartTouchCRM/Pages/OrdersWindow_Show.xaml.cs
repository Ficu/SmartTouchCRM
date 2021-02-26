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
using System.Windows.Shapes;

namespace SmartTouchCRM.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy OrdersWindow_Show.xaml
    /// </summary>
    public partial class OrdersWindow_Show : Window
    {
        private readonly Orders selectedProduct;
        private readonly OrderService OrderService = new OrderService();

        public OrdersWindow_Show(Orders selectedProduct)
        {
            InitializeComponent();

            this.selectedProduct = selectedProduct;
            FillData();
        }

        private void FillData()
        {
            OrderShowName_Label.Text = "Zamówienie numer " + selectedProduct.order_id;

            customerFirstname.Text = selectedProduct.Customers.firstname;
            customerLastname.Text = selectedProduct.Customers.lastname;
            customerMail.Text = selectedProduct.Customers.mail;
            customerTelephone.Text = selectedProduct.Customers.telephone;
            
            DateTime date = (DateTime)selectedProduct.order_date;
            var dateString = date.ToString("dd/MM/yyyy");
            orderDate.Text = dateString;

            orderValue.Text = selectedProduct.order_value.ToString();

            ProductOrder_Data.ItemsSource = OrderService.GetProducts(selectedProduct.order_id);
        }
    }
}
