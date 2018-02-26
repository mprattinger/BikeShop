using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example6._5.ViewModels
{
    public class CurrencyModel
    {
        public string Title { get; set; }
        public decimal Rate { get; set; }

        public CurrencyModel(string title, decimal rate)
        {
            Title = title;
            Rate = rate;
        }
    }

    public class CurrencyConverterViewModel : Notifier
    {
        private decimal _euros;
        public decimal Euros
        {
            get { return _euros; }
            set
            {
                _euros = value;
                OnPropertyChanged("Euros");
                OnEurosChanged();
            }
        }

        private decimal _converted;
        public decimal Converted
        {
            get { return _converted; }
            set
            {
                _converted = value;
                OnPropertyChanged("Converted");
            }
        }

        private CurrencyModel _selectedCurrency;
        public CurrencyModel SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
                OnSelectedCurrencyChanged();
            }
        }

        private IEnumerable<CurrencyModel> _currencies;
        public IEnumerable<CurrencyModel> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                OnPropertyChanged("Currencies");
            }
        }

        private string _resultText;
        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        public CurrencyConverterViewModel()
        {
            Currencies = new CurrencyModel[] { new CurrencyModel("US Dollar", 1.1M), new CurrencyModel("British Pound", 0.9M) };

        }

        private void OnSelectedCurrencyChanged()
        {
            ComputeConverted();
        }

        private void OnEurosChanged()
        {
            ComputeConverted();
        }

        private void ComputeConverted()
        {
            if (SelectedCurrency == null) return;

            Converted = Euros * SelectedCurrency.Rate;
            ResultText = $"Amount in {SelectedCurrency.Title}: ";
        }
    }
}
