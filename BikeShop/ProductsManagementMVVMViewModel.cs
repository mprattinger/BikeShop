using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    public class ProductsManagementMVVMViewModel: Notifier
    {
        #region Input and output Properties
        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set {
                _searchInput = value;
                OnPropertyChanged("SearchInput");
                _onSearchInputChanged();
            }
        }

        private IEnumerable<Product> _foundProducts;
        public IEnumerable<Product> FoundProducts
        {
            get { return _foundProducts; }
            set {
                _foundProducts = value;
                OnPropertyChanged("FoundProducts");
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        #endregion

        ProductsFactory _factory = new ProductsFactory();

        public ProductsManagementMVVMViewModel()
        {
            FoundProducts = Enumerable.Empty<Product>();

        }

        private void _onSearchInputChanged()
        {
            SelectedProduct = null;
            FoundProducts = _factory.FindProducts(SearchInput);
        }
    }
}
