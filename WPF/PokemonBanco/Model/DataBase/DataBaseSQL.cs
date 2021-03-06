using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBanco.Model.DataBase
{
    public class DataBaseSQL :  BaseNotify, IDataBase
    {
        private Message _msg;
        private SqlConnection _con;
        private SqlCommand _commandCarregar;
        private SqlCommand _commandAdcionar;
        private SqlCommand Command;
        private SqlDataReader _reader;
        private Pokemon _pmon;
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrador\Documents\C#_Learning\Treinamento-LUZ\WPF\PokemonBanco\PokmeonDB.mdf;Integrated Security=True";

        public DataBaseSQL()
        {
            Msg = new Message();
            Con = new SqlConnection(ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Con;
        }

        public Message Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        public SqlConnection Con
        {
            get { return _con; }
            set { _con = value; }
        }
        public SqlCommand CommandCarregar
        {
            get { return _commandCarregar; }
            set { _commandCarregar = value; }
        }
        public SqlCommand CommandAdcionar
        {
            get { return _commandAdcionar; }
            set { _commandAdcionar = value; }
        }
        public SqlDataReader Reader
        {
            get { return _reader; }
            set { _reader = value; }
        }
        public Pokemon Pmon
        {
            get { return _pmon; }
            set { _pmon = value; }
        }
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public void TrocarQuery(string query)
        {
            Command.CommandText = query;
        }

        public List<Pokemon> Carregar(List<Pokemon> lista)
        {
            Command.CommandText = "SELECT * FROM tbl_Pokemon";
            try
            {
                Con.Open();
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lista.Add(new Pokemon()
                        {
                            Id = Reader.GetInt32(0),
                            Nome = Reader.GetString(1),
                            Apelido = Reader.GetString(2),
                            Nivel = Reader.GetInt32(3),
                            Tipo = Reader.GetString(4)
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                Msg.ShowMessage(ex);
            }
            finally
            {
                if (Reader != null)
                {
                    Reader.Close();
                }
                Con.Close();
            }
            return lista;
        }

        public void Adicionar(Pokemon Pmon)
        {
            Command.CommandText = $"INSERT INTO tbl_Pokemon (Id, Nome, Apelido, Nivel, Tipo) Values ({Pmon.Id}, '{Pmon.Nome}', '{Pmon.Apelido}', {Pmon.Nivel}, '{Pmon.Tipo}');";
            try
            {
                Con.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Msg.ShowMessage(ex);
            }
            finally
            {
                Con.Close();
            }
        }

        public void Editar(Pokemon Pmon)
        {
            Command.CommandText = $"UPDATE tbl_Pokemon SET  Nome = '{Pmon.Nome}', Apelido = '{Pmon.Apelido}', Nivel = {Pmon.Nivel}, Tipo = '{Pmon.Tipo}' WHERE Id = {Pmon.Id};";
            try
            {
                Con.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Msg.ShowMessage(ex);
            }
            finally
            {
                Con.Close();
            }
        }

        public void Apagar(Pokemon Pmon)
        {
            Command.CommandText = $"DELETE FROM tbl_Pokemon WHERE Id = {Pmon.Id};";
            try
            {
                Con.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Msg.ShowMessage(ex);
            }
            finally
            {
                Con.Close();
            }
        }

        public List<Pokemon> GetLista()
        {
            throw new NotImplementedException();
        }
    }
}
