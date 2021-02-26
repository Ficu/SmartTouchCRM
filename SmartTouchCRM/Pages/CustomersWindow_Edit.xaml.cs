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
    /// Interaction logic for CustomersWindow_Edit.xaml
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

            string telephoneFormated = String.Concat(telephone.Text.Where(c => !Char.IsWhiteSpace(c)));

            if (string.IsNullOrWhiteSpace(firstName.Text.Trim()))
            {
                MessageBox.Show("Musisz podać imie", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (customer.ItHasDigit(firstName.Text.Trim()))
            {
                MessageBox.Show("W imieniu są cyfry", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(lastName.Text.Trim()))
            {
                MessageBox.Show("Musisz podać nazwisko", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;                
            }
            else if (customer.ItHasDigit(lastName.Text.Trim()))
            {
                MessageBox.Show("W nazwisku są cyfry", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!customer.IsDigitsOnly(telephoneFormated))
            {
                MessageBox.Show("Numer telefonu może zawierać tylko cyfry", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (telephoneFormated.Count() != 9)
            {
                MessageBox.Show("Numer telefonu musi mieć dokładnie 9 cyfr", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                customer.Update(selectedCustomer.customer_id, firstName.Text.Trim(), lastName.Text.Trim(), telephoneFormated, mail.Text.Trim());
            }

            this.Hide();
        }
    }
}
