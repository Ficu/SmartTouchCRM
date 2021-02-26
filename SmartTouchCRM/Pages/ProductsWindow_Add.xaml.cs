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
    /// Logika interakcji dla klasy ProductsWindow_Add.xaml
    /// </summary>
    public partial class ProductsWindow_Add : Window
    {        
        public ProductsWindow_Add()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ProductService product = new ProductService();

           bool result = Decimal.TryParse(productPrice.Text.Trim(), out decimal productPriceDecimal);
            if(string.IsNullOrWhiteSpace(productName.Text.Trim()))
            {
                MessageBox.Show("Nazwa produktu jest wymagana", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(!result)
            {
                MessageBox.Show("Cena musi być być liczbą", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else if (productPriceDecimal < 0)
            {                
                MessageBox.Show("Cena musi być większa bądź równa 0", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                product.Add(productName.Text.Trim(), productDescription.Text.Trim(), productPriceDecimal);
            }

            this.Hide();
        }
    }
}
