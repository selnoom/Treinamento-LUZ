using PokemonsTeste.Model;
using PokemonTeste;
using PokemonTeste.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonsTeste.ViewModel.MainWindowViewModel
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

            pokemonsLista.Add(new Pokemon()
            {
                Id = 1,
                Nome = "Bulbassaur",
                Apelido = "",
                Nivel = 1,
                Tipo = "Grama"
            });
            pokemonsLista.Add(new Dragonite(149, 60, "Dragonite", "Draginho", "Dragão"));
            PokemonSelecionado = pokemonsLista.FirstOrDefault();

            adicionar = new RelayCommand((object param) =>
            {
                PokemonWindow PW = new PokemonWindow();
                Pokemon PokemonClone = new Pokemon();
                PW.DataContext = PokemonClone;
                PW.ShowDialog();
                if (PW.DialogResult.HasValue && PW.DialogResult.Value)
                {
                    pokemonsLista.Add(PokemonClone);
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
                DataBaseWindow DW = new DataBaseWindow();
                DW.ShowDialog();
            });
        }

    }
}
