using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonsTeste.Model
{
    public class Pokemon : BaseNotify
    {
        private string _nome;
        public Pokemon()
        {

        }
        public int Id { get; set; }
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
                Notifica("Nome");
            }
        }
        public string Apelido { get; set; }
        public string Tipo { get; set; }
        public int Nivel { get; set; }
    }
}
