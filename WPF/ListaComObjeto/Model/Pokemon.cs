using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Lista.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Tipo { get; set; }
        public int Nivel { get; set; }
    }
}
