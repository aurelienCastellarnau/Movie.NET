using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfApp3
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Name = "Hello MVVM";
            MyCommande = new RelayCommand(MyCommandeExecute, MyCommandeCanExecute);
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand MyCommande { get; }

        void MyCommandeExecute()
        {
            Name = "Hello click!";
        }

        bool MyCommandeCanExecute()
        {
            return Name != "Hello click!";
        }
    }
}
