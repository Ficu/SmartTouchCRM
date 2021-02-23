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
            Decimal.TryParse(productPrice.Text, out decimal productPriceDecimal);
            product.Add(productName.Text, productDescription.Text, productPriceDecimal);
            this.Hide();
        }
    }
}
