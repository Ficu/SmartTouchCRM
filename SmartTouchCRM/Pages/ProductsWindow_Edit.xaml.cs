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
    /// Interaction logic for ProductsWindow_Edit.xaml
    /// </summary>
    public partial class ProductsWindow_Edit : Window
    {
        private readonly Products productSelected;

        public ProductsWindow_Edit(Products productSelected)
        {
            InitializeComponent();
            this.productSelected = productSelected;
            FillData();
        }

        private void FillData()
        {
            productName.Text = productSelected.product_name;
            productPrice.Text = Convert.ToString(productSelected.price);
            productDescription.Text = productSelected.product_description;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ProductService product = new ProductService();

            bool result = Decimal.TryParse(productPrice.Text.Trim(), out decimal productPriceDecimal);
            if (string.IsNullOrWhiteSpace(productName.Text.Trim()))
            {
                MessageBox.Show("Nazwa produktu jest wymagana", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!result)
            {
                MessageBox.Show("Cena musi być być liczbą", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (productPriceDecimal < 0)
            {
                MessageBox.Show("Cena musi być większa bądź równa 0", "Niepoprawne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                product.Update(productSelected.product_id, productName.Text, productDescription.Text, productPriceDecimal);                
            }

            this.Hide();
        }
    }
}
