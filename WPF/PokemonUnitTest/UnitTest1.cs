using NUnit.Framework;
using PokemonBanco.Model;
using PokemonBanco.Model.DataBase;
using System.Collections.Generic;
using Moq;
using PokemonBanco;
using System.Collections.ObjectModel;

namespace PokemonUnitTest
{
    public class Tests
    {
        [Test]

        public void nome()
        {
            //arrange

            //act

            //assert
        }

        [Test]
        public void CriarPokemonClone()
        {
            //arrange
            Pokemon pmon = new Pokemon()
            {
                Id = 2,
                Nome = "clone",
                Apelido = null,
                Nivel = 0,
                Tipo = null,
            };

            //act
            Pokemon clone = pmon.Clone();

            //assert
            Assert.AreEqual(pmon.Id, clone.Id);
            Assert.AreEqual(pmon.Nome, clone.Nome);
            Assert.AreEqual(pmon.Apelido, clone.Apelido);
            Assert.AreEqual(pmon.Nivel, clone.Nivel);
            Assert.AreEqual(pmon.Tipo, clone.Tipo);
        }

        [Test]

        public void PostgresCarregarBancodeDados()
        {
            //arrange
            IDataBase DBase;

            //act
            DBase = DataBaseSelecao.CarregarDefault("Postgres");

            //assert
            Assert.IsInstanceOf<DataBasePostgres>(DBase);
        }

        [Test]

        public void InserirPokemon()
        {
            //arrange
            Pokemon Pmon = new Pokemon()
            {
                Id = 83,
                Nome = "testeNome",
                Apelido = "testeApelido",
                Nivel = 20,
                Tipo = "testeTipo",
            };
            List<Pokemon> pokemonLista;
            List<Pokemon> lista = new List<Pokemon>();
            DataBasePostgres DBase = new DataBasePostgres();

            //act
            DBase.Adicionar(Pmon);
            pokemonLista = new List<Pokemon>(DBase.Carregar(lista));

            //assert
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Id, Pmon.Id);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Nome, Pmon.Nome);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Apelido, Pmon.Apelido);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Nivel, Pmon.Nivel);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Tipo, Pmon.Tipo);
        }

        [Test]
        public void EditarPokemon()
        {
            //arrange
            Pokemon Pmon = new Pokemon()
            {
                Id = 7,
                Nome = "testeEdicao",
                Apelido = "testeApelido",
                Nivel = 20,
                Tipo = "testeTipo",
            };
            List<Pokemon> pokemonLista;
            List<Pokemon> lista = new List<Pokemon>();
            DataBasePostgres DBase = new DataBasePostgres();

            //act
            DBase.Editar(Pmon);
            pokemonLista = new List<Pokemon>(DBase.CarregarId(Pmon, lista));

            //assert
            Assert.AreEqual(pokemonLista[0].Id, Pmon.Id);
            Assert.AreEqual(pokemonLista[0].Nome, Pmon.Nome);
            Assert.AreEqual(pokemonLista[0].Apelido, Pmon.Apelido);
            Assert.AreEqual(pokemonLista[0].Nivel, Pmon.Nivel);
            Assert.AreEqual(pokemonLista[0].Tipo, Pmon.Tipo);
        }

        [Test]

        public void InserirPokemonMock() 
        {
            //arrange
            Pokemon Pmon = new Pokemon()
            {
                Id = 13,
                Nome = "Mock",
                Apelido = "testeApelido",
                Nivel = 20,
                Tipo = "testeTipo",
            };
            Pokemon pokemonTemporario = new Pokemon();
            ObservableCollection<Pokemon> pokemonLista = new ObservableCollection<Pokemon>();
            Mock<IDataBase> mockDataBase = new Mock<IDataBase>();
            mockDataBase.Setup(x => x.Adicionar(Pmon));

            //act
            Comandos.Adicionar(mockDataBase.Object, pokemonLista, Pmon);

            //assert
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Id, Pmon.Id);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Nome, Pmon.Nome);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Apelido, Pmon.Apelido);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Nivel, Pmon.Nivel);
            Assert.AreEqual(pokemonLista[pokemonLista.Count - 1].Tipo, Pmon.Tipo);

        }


    }
}