using CRUD_Lista;
using CRUD_Lista.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListaComObjeto.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pokemon> pokemons { get; set; }

        public Pokemon PokemonSelecionado { get; set; }

        public Pokemon PokemonNome { get; set; }

        public ICommand adicionar { get; private set; }

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }

        public MainWindowViewModel()
        {
            pokemons = new ObservableCollection<Pokemon>();
            pokemons.Add(new Pokemon
            {
                Id = 1,
                Nome = "Bulbassaur",
                Apelido = null,
                Nivel = 1,
                Tipo = "Grama"
            });


            adicionar = new RelayCommand((object param) =>
            {
                
            });

            apagar = new RelayCommand((object param) =>
            {
                    pokemons.Remove(PokemonSelecionado);
            });

            editar = new RelayCommand((object param) =>
            {
                //PokemonSelecionado.Nome = PokemonNome;
            });
        }




        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void Notifica(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
