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

        /*public int PokemonId { get; set; }
        public string PokemonNome { get; set; }
        public string PokemonApelido { get; set; }
        public int PokemonNivel { get; set; }
        public string PokemonTipo { get; set; }*/

        public ICommand adicionar { get; private set; }

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }

        public MainWindowViewModel()
        {
            pokemonsLista = new ObservableCollection<Pokemon>();
            PokemonPreenchido = new Pokemon();
            pokemonsLista.Add(new Pokemon
            {
                Id = 1,
                Nome = "Bulbassaur",
                Apelido = null,
                Nivel = 1,
                Tipo = "Grama"
            });


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
                    PokemonSelecionado.Id = PokemonPreenchido.Id;
                    //PokemonSelecionado.Nome = PokemonPreenchido.Nome;
                    pokemonsLista[0].Nome = PokemonPreenchido.Nome;
                    PokemonSelecionado.Apelido = PokemonPreenchido.Apelido;
                    PokemonSelecionado.Nivel = PokemonPreenchido.Nivel;
                    PokemonSelecionado.Tipo = PokemonPreenchido.Tipo;
                }
            });
        }

    }
}
