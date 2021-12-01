using PokemonTeste;
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
        private int _id;
        private string _apelido;
        private int _nivel;
        private string _tipo;
        public Pokemon()
        {
            
        }

        public Pokemon(int id, int nivel, string nome, string apelido, string tipo)
        {
            Id = id;
            Nivel = nivel;
            Nome = nome;
            Apelido = apelido;
            Tipo = tipo;
        }

        //Construtor ou método para clonar pokemon

        public Pokemon(Pokemon Clone)
        {
            Id=Clone.Id;
            Nivel=Clone.Nivel;
            Nome=Clone.Nome;
            Apelido = Clone.Apelido;
            Tipo=Clone.Tipo;
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
