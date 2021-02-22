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
    /// Logika interakcji dla klasy ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {

        ProductService ProductService = new ProductService();

        public ProductsPage()
        {
            InitializeComponent();
            Product_Data.ItemsSource = ProductService.GetList();

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
            ProductsWindow_Add test = new ProductsWindow_Add();
            test.ShowDialog();

        }
    }
}
