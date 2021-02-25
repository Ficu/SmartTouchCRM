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
    /// Logika interakcji dla klasy CustomersWindow_Edit.xaml
    /// </summary>
    public partial class CustomersWindow_Edit : Window
    {
        private readonly Customers selectedCustomer;

        public CustomersWindow_Edit(Customers selectedCustomer)
        {
            InitializeComponent();
            this.selectedCustomer = selectedCustomer;
            FillData();
        }

        private void FillData()
        {
            firstName.Text = selectedCustomer.firstname;
            lastName.Text = selectedCustomer.lastname;
            telephone.Text = selectedCustomer.telephone;
            mail.Text = selectedCustomer.mail;       
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            CustomersService customer = new CustomersService();

            //Decimal.TryParse(productPrice.Text, out decimal productPriceDecimal);

            customer.Update(selectedCustomer.customer_id, firstName.Text, lastName.Text, telephone.Text, mail.Text);

            this.Hide();
        }
    }
}
