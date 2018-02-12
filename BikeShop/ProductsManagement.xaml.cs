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

namespace BikeShop
{
    /// <summary>
    /// Interaktionslogik für ProductsManagement.xaml
    /// </summary>
    public partial class ProductsManagement : Page
    {
        private readonly ProductsFactory factory = new ProductsFactory();

        public ProductsManagement()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dg1.ItemsSource = factory.FindProducts("");
        }
    }
}
