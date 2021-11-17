using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.ViewModel
{
    public class FuncionariosViewModel : BaseNotifyPropertyChanged //O que vem depois dos ":"?
    {
        public System.Collections.ObjectModel.ObservableCollection<Model.Funcionario> Funcionarios { get; private set; }

        private Model.Funcionario _funcionarioSelecionado;
        public Model.Funcionario FuncionarioSelecionado
        {
            //Como exatamente funciona get e set? Enviar e receber valores?
            get { return _funcionarioSelecionado; }
            set { SetField(ref _funcionarioSelecionado, value); }
        }

        public FuncionariosViewModel()
        {
            Funcionarios = new System.Collections.ObjectModel.ObservableCollection<Model.Funcionario>();
            Funcionarios.Add(new Model.Funcionario()
            {
                Id = 1,
                Nome = "Nicholas",
                Sobrenome = "Peçanha",
                DataNascimento = new DateTime(1997, 07, 12),
                Sexo = Model.Sexo.Masculino,
                EstadoCivil = Model.EstadoCivil.Solteiro,
                DataAdmissao = new DateTime(2021, 11, 16)
            });

            FuncionarioSelecionado = Funcionarios.FirstOrDefault();
        }

        public DeletarCommand Deletar { get; private set; } = new DeletarCommand();

        public class DeletarCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as FuncionariosViewModel;
                return viewModel != null && viewModel.FuncionarioSelecionado != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                viewModel.Funcionarios.Remove(viewModel.FuncionarioSelecionado);
                viewModel.FuncionarioSelecionado = viewModel.Funcionarios.FirstOrDefault();
            }
        }

        public NovoCommand Novo { get; private set; } = new NovoCommand();
        public class NovoCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is FuncionariosViewModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                var funcionario = new Model.Funcionario();
                var maxId = 0;
                if (viewModel.Funcionarios.Any())
                {
                    maxId = viewModel.Funcionarios.Max(f => f.Id);
                }
                funcionario.Id = maxId + 1;

                var fw = new AddWindow();
                fw.DataContext = funcionario;
                fw.ShowDialog();

                if (fw.DialogResult.HasValue && fw.DialogResult.Value)
                {
                    viewModel.Funcionarios.Add(funcionario);
                    viewModel.FuncionarioSelecionado = funcionario;
                }
            }
        }
    }
}
