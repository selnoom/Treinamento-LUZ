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
        public ObservableCollection<string> lista { get; set; }
        public ObservableCollection<Model.Pokemon> pokemons { get; set; }

        public string nome { get; set; }
        public Model.Pokemon nomePokemon { get; set; }

        public Model.Pokemon PokemonSelecionado {get; set;}
        public string value { get; set; }
        public int index { get; set; }

        public ICommand adicionar { get; private set;}

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }

        public ICommand adicionar2 { get; private set; }

        public ICommand apagar2 { get; private set; }

        public ICommand editar2 { get; private set; }


        public MainWindowViewModel()
        {
            lista = new ObservableCollection<string>();
            pokemons = new ObservableCollection<Model.Pokemon>();
            lista.Add("Pedra");
            lista.Add("Sacola");
            lista.Add("Coca");
            pokemons.Add(new Model.Pokemon
            {
                Id = 1,
                Nome = "Bulbassaur",
                Apelido = null,
                Nivel = 1,
                Tipo = "Grama"
            });


            adicionar = new RelayCommand((object param) =>
            {
                lista.Add(nome);
            });

            apagar = new RelayCommand((object param) =>
            {
                lista.RemoveAt(index);
            });

            apagar2 = new RelayCommand((object param) =>
            {
                pokemons.Remove(PokemonSelecionado);
            });

            editar = new RelayCommand((object param) =>
            {
                lista[index] = nome;
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
