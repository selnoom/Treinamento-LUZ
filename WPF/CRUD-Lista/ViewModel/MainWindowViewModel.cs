using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CRUD_Lista.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> lista { get; set;}
        public string nome { get; set;}
        public string value { get; set; }

        public ICommand adicionar { get; private set;}

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }


        public MainWindowViewModel()
        {
            lista = new ObservableCollection<string>();
            lista.Add("Pedra");
            lista.Add("Sacola");
            lista.Add("Coca");
            adicionar = new RelayCommand((object param) =>
            {
                lista.Add(nome);
            });

            apagar = new RelayCommand((object param) =>
            {
                lista.Remove(value);
            });

            editar = new RelayCommand((object param) =>
            {
                lista.Remove(value);
                lista.Add(nome);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void Notifica(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
