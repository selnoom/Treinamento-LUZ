using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Model
{
    public class Pokemon : BaseNotify
    {
        private string _nome;
        private int _id;
        private string _apelido;
        private string _tipo;
        private int _nivel;
        public Pokemon()
        {

        }

        public Pokemon(int id, string nome, string apelido, string tipo, int nivel)
        {
            _id = id;
            _nome = nome;
            _apelido = apelido;
            _tipo = tipo;
            _nivel = nivel;
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
