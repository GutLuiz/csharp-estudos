using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex15
    {
        public class Funcionario
        {
            protected string _nome;
            protected int _cpf;
            protected decimal _salarioBase;

            public Funcionario(string nome, int cpf, decimal salario)
            {
                _nome = nome;
                _cpf = cpf;
                _salarioBase = salario;
            }

            public virtual decimal CalcularSalario()
            {
                return _salarioBase;
            }
            public virtual string ObterCargo()
            {
                return "Funcionario";
            }
            public override string ToString()
            {
                return "Nome: " + _nome + ", Cargo: " + ObterCargo() + ", Salario: " + CalcularSalario();
            }
        }
        public class Gerente : Funcionario
        {
            private int _tamanhoEquipe;

            public Gerente(string nome, int cpf, decimal salario, int equipe) : base(nome, cpf, salario)
            {
                _tamanhoEquipe = equipe;
            }
            public override decimal CalcularSalario()
            {
                return base.CalcularSalario() + (_tamanhoEquipe * 200);
            }
            public override string ObterCargo()
            {
                return "Gerente";
            }
        }
        public class Vendedor : Funcionario
        {
            private decimal _vendasMensal;

            public Vendedor(string nome, int cpf, decimal salario, decimal vendaMensal) : base(nome, cpf, salario)
            {
                _vendasMensal = vendaMensal;
            }
            public override decimal CalcularSalario()
            {
                return base.CalcularSalario() + (_vendasMensal * 0.05m);
            }
            public override string ObterCargo()
            {
                return "Vendedor";
            }
        }
        public class Estagiario : Funcionario
        {
            private string _dataFimContrato;

            public Estagiario(string nome, int cpf, decimal salario, string dataFim) : base(nome, cpf, salario)
            {
                _dataFimContrato = dataFim;
            }
            public override decimal CalcularSalario()
            {
                return base._salarioBase * 0.6m;
            }
            public override string ObterCargo()
            {
                return "Estagiario";
            }
        }
        public class Empresa
        {
            private string _nomeEmpresa;
            private List<Funcionario> _f = new List<Funcionario>();

            public Empresa(string nome) 
            {
                _nomeEmpresa = nome;
            }

            public void AdicionarFuncionario(Funcionario f)
            {
                _f.Add(f);
            }
            public void ExibirTodos()
            {
                foreach(Funcionario f in _f)
                {
                    Console.WriteLine(f.ToString());
                }
            }
            public decimal CalcularFolha()
            {
                decimal totalFolha = 0;
                foreach(Funcionario f in _f)
                {
                    totalFolha += f.CalcularSalario();
                }

                return totalFolha;
            }
            public string MaiorSalario()
            {
                Funcionario maiorSalario = null;

                foreach(Funcionario f in _f)
                {
                    if (maiorSalario == null || f.CalcularSalario() > maiorSalario.CalcularSalario())
                    {
                        maiorSalario = f;
                    }
                }

                return maiorSalario.ToString();
            }
        }
        public void Executar()
        {
            Gerente g1= new Gerente("Gustavo", 1243556, 2500m, 5);
            Gerente g2 = new Gerente("lucas", 124223556, 1500m, 2);

            Vendedor v1 = new Vendedor("Kaue", 12555, 500m, 650m);
            Vendedor v2 = new Vendedor("laercio", 112555, 240m, 150m);

            Estagiario e1 = new Estagiario("Nivaldo", 5556888, 500m, "12/05/2026");
            Estagiario e2 = new Estagiario("juliana", 15556888, 500m, "12/12/2026");

            Empresa e = new Empresa("LGN SOLUCOES");

            e.AdicionarFuncionario(g1);
            e.AdicionarFuncionario(g2);
            e.AdicionarFuncionario(v1);
            e.AdicionarFuncionario(v2);
            e.AdicionarFuncionario(e1);
            e.AdicionarFuncionario(e2);

            e.ExibirTodos();

            Console.WriteLine("Folha total: " + e.CalcularFolha());
            Console.WriteLine("Maior salario: " + e.MaiorSalario());
        }
    }
}
