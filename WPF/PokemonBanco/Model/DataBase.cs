using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonBanco.Model
{

    public class DataBase
    {

        Message msg = new Message();
        public static string connectionString = @"Server=127.0.0.1;Port=5555;User Id=nicholas;Password=1234;DataBase=nicholas;";

        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            return con;
        }



        public NpgsqlCommand Leitura(NpgsqlConnection con)
        {
            return new NpgsqlCommand("SELECT * FROM tbl_Pokemon", con);
        } 

        public DataTable GetDataTable()
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                DataTable db = new DataTable();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM tbl_Pokemon", con);
                adapter.Fill(db);
                return db;
            }
            catch 
            {
                msg.ShowMessage();
                return null;
            }
        }

    }
}
