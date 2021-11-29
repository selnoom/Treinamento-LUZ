using CRUD_Lista;
using CRUD_Lista.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListaComObjeto.ViewModel
{
    public class PokemonWindowViewModel : MainWindowViewModel
    {
        public ICommand adicionar2 { get; private set; }
        public PokemonWindowViewModel()
        {
            adicionar2 = new RelayCommand((object param) =>
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
        }
    }
}
