using PokemonBanco.Model;
using PokemonBanco.Model.DataBase;
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
        private IDataBase _dBase;
        private PokemonWindow _pW;
        private Pokemon _pokemonTemporario;
        private Comandos _comm;
        
        public MainWindowViewModel()
        {
            lista = new List<Pokemon>();
            DB_Selecao = new DataBaseSelecao();
            DBase = DB_Selecao.Carregar("Postgres");
            pokemonsLista = new ObservableCollection<Pokemon>(DBase.Carregar(lista));
            PokemonTemporario = new Pokemon();


            adicionar = new RelayCommand((object param) => 
            {
                Pokemon.Limpar(PokemonTemporario);
                PW = new PokemonWindow();
                PW.DataContext = PokemonTemporario;
                PW.ShowDialog();
                if (PW.DialogResult.HasValue && PW.DialogResult.Value)
                {
                    Comandos.Adicionar(DBase, pokemonsLista, PokemonTemporario);
                }
            });

            apagar = new RelayCommand((object param) =>
            {
                if (PokemonSelecionado != null)
                {
                    Comandos.Apagar(DBase, pokemonsLista, PokemonSelecionado);
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
                    Pokemon PokemonClone = PokemonSelecionado.Clone();
                    PW = new PokemonWindow();
                    PW.DataContext = PokemonClone;
                    PW.ShowDialog();
                    if (PW.DialogResult.HasValue && PW.DialogResult.Value)
                    {
                        Comandos.Editar(DBase, PokemonSelecionado, PokemonClone);
                    }
                }
            });
        }
        public ObservableCollection<Pokemon> pokemonsLista { get; set; }
        public List<Pokemon> lista { get; set; }
        public Pokemon PokemonSelecionado { get; set; }
        public Pokemon PokemonTemporario
        {
            get { return _pokemonTemporario; }
            set { _pokemonTemporario = value; }
        }
        public IDataBase DBase
        {
            get { return _dBase; }
            set { _dBase = value; }

        }
        public PokemonWindow PW
        {
            get { return _pW; }
            set { _pW = value; }
        }
        public Comandos Comm
        {
            get { return _comm; }
            set { _comm = value; }
        }
        public DataBaseSelecao DB_Selecao { get; set; }
        public ICommand adicionar { get; private set; }

        public ICommand apagar { get; private set; }

        public ICommand editar { get; private set; }

        public ICommand abrirBanco { get; private set; }

    }
}
