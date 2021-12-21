using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBanco.Model.DataBase
{
    public class DataBaseSelecao
    {
        private static Dictionary<string, IDataBase> Bancos;

        public DataBaseSelecao(bool isDefault = true)
        {
            Bancos = new Dictionary<string, IDataBase>();
            if (isDefault)
            {
                Bancos.Add("SQL", new DataBaseSQL());
                Bancos.Add("Postgres", new DataBasePostgres());
            }
        }

        public IDataBase Carregar(string chave)
        {
            if (Bancos.TryGetValue(chave, out IDataBase db))
            {
                return db;
            }
            else
            {
                return null;
            }
        }

        public void AdicionarNovo(string chave, IDataBase Banco)
        {
            Bancos.Add(chave, Banco);
        }


    }
}
