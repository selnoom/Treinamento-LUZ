using PokemonsTeste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTeste.Model
{
    public class Dragonite : Pokemon
    {
        public int Ataque;

        public Dragonite(int id, int nivel, string nome, string apelido, string tipo)
        {
            Id = id;
            Nivel = nivel;
            Nome = nome;
            Apelido = apelido;
            Tipo = tipo;
            Ataque = 100;
        }
    }
}
