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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        readonly ProductService ProductService = new ProductService();

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
            ProductsWindow_Add addWindow = new ProductsWindow_Add();
            addWindow.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            SmartTouchDatabseEntities _reload = new SmartTouchDatabseEntities();
            Product_Data.ItemsSource = _reload.Products.ToList();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            Products selectedProduct = (Product_Data.SelectedItem as Products);
            if (selectedProduct == null)
            {
                MessageBox.Show("Musisz najpierw wybrać produkt!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {            

                ProductsWindow_Edit editWindow = new ProductsWindow_Edit(selectedProduct);
                editWindow.ShowDialog();
                Reload();
                
            }
            
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Product_Data.SelectedItem == null)
            {
                MessageBox.Show("Musisz najpierw wybrać produkt", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int selectedProductId = (Product_Data.SelectedItem as Products).product_id;

                MessageBoxResult decision = MessageBox.Show("Czy na pewno chcesz usunąć zamówienie?", "Ostrzeżenie", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (decision == MessageBoxResult.Yes)
                {

                    if (ProductService.Remove(selectedProductId))
                    {
                        MessageBox.Show("Wybrany rekord został usunięty", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("Nie możesz usunąć rekordu, znajduje się on w zamówieniu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
