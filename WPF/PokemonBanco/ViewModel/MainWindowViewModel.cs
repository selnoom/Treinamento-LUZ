using PokemonBanco.Model;
using PokemonBanco;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using Npgsql;


namespace PokemonBanco.ViewModel.MainWindowViewModel 
{
    public class MainWindowViewModel : BaseNotify
    {

        public ObservableCollection<Pokemon> pokemonsLista { get; set; }

        public Pokemon PokemonSelecionado { get; set; }
        public ICommand adicionar { get; private set; }

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }

        public ICommand abrirBanco { get; private set; }

        

        public MainWindowViewModel()
        {
            pokemonsLista = new ObservableCollection<Pokemon>();
            PokemonSelecionado = pokemonsLista.FirstOrDefault();
            DataBase dBase = new DataBase();


            DataTable db = dBase.GetDataTable();
            


            //NpgsqlDataReader reader = leitura.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    DataTable dt = new DataTable();
            //    dt.Load(reader);
            //}
            //leitura.Dispose();
            //con.Close();


            //{
            //    pokemonsLista.Add(new Pokemon()
            //    {
            //        Id = reader.GetInt32(0),
            //        Nome = reader.GetString(1),
            //        Apelido = (string)reader["Apelido"].ToString(),
            //        Nivel = (int)reader["Nivel"],
            //        Tipo = (string)reader["Tipo"].ToString()
            //    });
            //}

            //try
            //{
            //    conn.Open();
            //    SqlDataReader reader = leitura.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        pokemonsLista.Add(new Pokemon()
            //        {
            //            //Id = (int)reader["ID"],
            //            Id = reader.GetInt32(0),
            //            Nome = reader.GetString(1),
            //            Apelido = (string)reader["Apelido"].ToString(),
            //            Nivel = (int)reader["Nivel"],
            //            Tipo = (string)reader["Tipo"].ToString()
            //        });
            //    }
            //    reader.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    //conn.Close();
            //}

            adicionar = new RelayCommand((object param) =>
            {
                PokemonWindow PW = new PokemonWindow();
                Pokemon PokemonClone = new Pokemon();
                PW.DataContext = PokemonClone;
                PW.ShowDialog();
                if (PW.DialogResult.HasValue && PW.DialogResult.Value)
                {
                    //SqlCommand novo = new SqlCommand($"INSERT INTO tbl_Pokemon ('Nome', 'Apelido', 'Nivel', 'Tipo') Values ({PokemonClone.Nome},{PokemonClone.Apelido},{PokemonClone.Nivel}, {PokemonClone.Tipo})", conn);
                    //novo.ExecuteNonQuery();
                    //pokemonsLista.Add(PokemonClone);
                }

            });

            apagar = new RelayCommand((object param) =>
            {
                if (PokemonSelecionado != null)
                {
                    pokemonsLista.Remove(PokemonSelecionado);
                }

            },
                (object param) =>
                {
                    return pokemonsLista.Count > 0;
                }
                );

            editar = new RelayCommand((object param) =>
            {
                if (PokemonSelecionado != null)
                {
                    PokemonWindow PW = new PokemonWindow();
                    Pokemon PokemonClone = PokemonSelecionado.Clone();
                    PW.DataContext = PokemonClone;
                    PW.ShowDialog();
                    if (PW.DialogResult.HasValue && PW.DialogResult.Value)
                    {
                        PokemonSelecionado.Id = PokemonClone.Id;
                        PokemonSelecionado.Nivel = PokemonClone.Nivel;
                        PokemonSelecionado.Nome = PokemonClone.Nome;
                        PokemonSelecionado.Apelido = PokemonClone.Apelido;
                        PokemonSelecionado.Tipo = PokemonClone.Tipo;
                    }
                }
            });

            abrirBanco = new RelayCommand((object param) =>
            {
                
            });
        }
    }
}
