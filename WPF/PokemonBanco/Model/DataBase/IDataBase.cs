using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBanco.Model.DataBase
{ 
    public interface IDataBase
    {

        List<Pokemon> Carregar(List<Pokemon> lista);
        void Adicionar(Pokemon Pmon);
        void Editar(Pokemon Pmon);
        void Apagar(Pokemon Pmon);

    }
}
