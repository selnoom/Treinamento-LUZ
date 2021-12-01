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
    public class MainWindowViewModel 
    {

        public ObservableCollection<Pokemon> pokemonsLista { get; set; }

        public Pokemon PokemonSelecionado { get; set; }
        public Pokemon PokemonPreenchido { get; set; }

        public ICommand adicionar { get; private set; }

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }

        public MainWindowViewModel()
        {
            pokemonsLista = new ObservableCollection<Pokemon>();
            PokemonPreenchido = new Pokemon();
            

            pokemonsLista.Add(new Pokemon()
            {
                Id = 1,
                Nome = "Bulbassaur",
                Apelido = "",
                Nivel = 1,
                Tipo = "Grama"
            });
            PokemonSelecionado = pokemonsLista.FirstOrDefault();

            adicionar = new RelayCommand((object param) =>
            {
                pokemonsLista.Add(new Pokemon
                {
                    Id = PokemonPreenchido.Id,
                    Nome = PokemonPreenchido.Nome,
                    Apelido = PokemonPreenchido.Apelido,
                    Nivel = PokemonPreenchido.Nivel,
                    Tipo = PokemonPreenchido.Tipo
                });
                
            });

            apagar = new RelayCommand((object param) =>
            {
                if (PokemonSelecionado != null)
                {
                    pokemonsLista.Remove(PokemonSelecionado);
                }
                
            });

            editar = new RelayCommand((object param) =>
            {
                if (PokemonSelecionado != null)
                {
                    PokemonWindow PW = new PokemonWindow();
                    PW.DataContext = PokemonSelecionado;
                    PW.ShowDialog();
                    //PokemonSelecionado.Id = PokemonPreenchido.Id;
                    //pokemonsLista[0].Nome = "Charmander";
                    //PokemonSelecionado.Apelido = PokemonPreenchido.Apelido;
                    //PokemonSelecionado.Nivel = PokemonPreenchido.Nivel;
                    //PokemonSelecionado.Tipo = PokemonPreenchido.Tipo;
                }
                pokemonsLista.Add(new Pokemon());
            });
        }

    }
}
