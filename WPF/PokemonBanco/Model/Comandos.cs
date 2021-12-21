using PokemonBanco.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBanco.Model
{
    public class Comandos
    {
        public Comandos()
        {

        }
        public static void Adicionar(IDataBase DBase, ObservableCollection<Pokemon> pokemonsLista, Pokemon PokemonTemporario)
        {
            DBase.Adicionar(PokemonTemporario);
            pokemonsLista.Add(PokemonTemporario);
        }

        public static void Apagar(IDataBase DBase, ObservableCollection<Pokemon> pokemonsLista, Pokemon PokemonSelecionado)
        {
            DBase.Apagar(PokemonSelecionado);
            pokemonsLista.Remove(PokemonSelecionado);
        }

        public static void Editar(IDataBase DBase, Pokemon PokemonSelecionado, Pokemon PokemonClone)
        {
            DBase.Editar(PokemonClone);
            PokemonSelecionado.Id = PokemonClone.Id;
            PokemonSelecionado.Nivel = PokemonClone.Nivel;
            PokemonSelecionado.Nome = PokemonClone.Nome;
            PokemonSelecionado.Apelido = PokemonClone.Apelido;
            PokemonSelecionado.Tipo = PokemonClone.Tipo;
        }
    }
}
