using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace CRUD_1._0
{
    public class MainWindowsViewModelBase1
    {
        public List<string> lista { get; set; }
        public string nome { get; set; }

        public ICommand comando { get; private set; }

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