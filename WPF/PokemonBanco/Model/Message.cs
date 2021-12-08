using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonBanco.Model
{
    public class Message
    {
        public void ShowMessage()
        {
            NpgsqlException ex = new NpgsqlException();
            MessageBox.Show(ex.Message);
        }
    }
}
