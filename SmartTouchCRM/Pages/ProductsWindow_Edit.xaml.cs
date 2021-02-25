﻿using SmartTouchCRM.Classes;
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
    /// Logika interakcji dla klasy ProductsWindow_Edit.xaml
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

            Decimal.TryParse(productPrice.Text, out decimal productPriceDecimal);

            product.Update(productSelected.product_id, productName.Text, productDescription.Text, productPriceDecimal);

            this.Hide();
        }
    }
}
