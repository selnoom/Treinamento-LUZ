using PokemonBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBanco.Model
{
    public class Pokemon : BaseNotify
    {
        private string _nome;
        private int _id;
        private string _apelido;
        private int _nivel;
        private string _tipo;
        public Pokemon()
        {

        }

        public Pokemon(int _id, int _nivel, string _nome, string _apelido, string _tipo)
        {
            this._id = _id;
            this._nivel = _nivel;
            this._nome = _nome;
            this._apelido = _apelido;
            this._tipo = _tipo;
        }

        private Pokemon(Pokemon P)
        {
            Id = P.Id;
            Nivel = P.Nivel;
            Nome = P.Nome;
            Apelido = P.Apelido;
            Tipo = P.Tipo;
        }

        public Pokemon Clone()
        {
            return new Pokemon(this);
        }



        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                Notifica("Id");
            }
        }
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
        public string Apelido
        {
            get
            {
                return _apelido;
            }
            set
            {
                _apelido = value;
                Notifica("Apelido");
            }
        }
        public string Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
                Notifica("tipo");
            }
        }
        public int Nivel
        {
            get
            {
                return _nivel;
            }
            set
            {
                _nivel = value;
                Notifica("Nivel");
            }
        }
    }
}
