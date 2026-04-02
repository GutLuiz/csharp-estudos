using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex11
    {
        public class Funcionario
        {
            private string _nome;
            private string _cargo;
            private decimal _salarioBase;
            private int _horasExtras;

            public Funcionario(string nome, string cargo, decimal salario, int horas)
            {
                _nome = nome;
                _cargo = cargo;
                _salarioBase = salario;
                _horasExtras = horas;
            }

            public string ObterNome()
            {
                return _nome;
            }
            public string ObterCargo()
            {
                return _cargo;
            }
            public decimal ObterSalario()
            {
                return _salarioBase;
            }
            public int ObterHoras()
            {
                return _horasExtras;
            }
            public void RegistrarHoraExtra()
            {
                _horasExtras ++;
            }
            public decimal CalcularSalarioFinal()
            {
                return _salarioBase + (_horasExtras * 50);
            }
            public void ExibirFuncionario()
            {
                Console.WriteLine("Funcionario: " + _nome + ", Cargo: " + _cargo + ", Salario base: " + _salarioBase + "horas extras: " + _horasExtras + 
                    ", Salario final: " + CalcularSalarioFinal());
            }
        }
        public class Departamento
        {
            private string _nomeDepartamento;
            private List<Funcionario> _func = new List<Funcionario>();

            public Departamento(string departamento)
            {
                _nomeDepartamento = departamento;
            }

            public void AdicionarFuncionario(Funcionario u)
            {
                _func.Add(new Funcionario(u.ObterNome(), u.ObterCargo(), u.ObterSalario(), u.ObterHoras()));
            }
            public void ExibirTodos()
            {
                foreach(Funcionario f in _func)
                {
                    f.ExibirFuncionario();
                }
            }
            public void ExibirMaiorSalario()
            {
                Funcionario maior = null;
                foreach (Funcionario f in _func)
                {
                   if(maior == null || f.CalcularSalarioFinal() > maior.CalcularSalarioFinal())
                    {
                        maior = f;
                    }
                }
                maior.ExibirFuncionario();
            }
            public decimal CalcularFolha()
            {
                decimal total = 0;
                foreach(Funcionario f in _func)
                {
                    total += f.CalcularSalarioFinal();
                }
                return total;
            }
        }
        public void Executar()
        {
            Departamento dp = new Departamento("RH");
            Funcionario func = new Funcionario("Gustavo", "Administrador", 5000m, 5);
            Funcionario func2 = new Funcionario("kaue", "gerente", 2500m, 0);
            Funcionario func3 = new Funcionario("laercio", "estagiario", 600m, 2);
            Funcionario func4 = new Funcionario("lucas", "secretario", 2000m, 10);

            dp.AdicionarFuncionario(func);
            dp.AdicionarFuncionario(func2);
            dp.AdicionarFuncionario(func3);
            dp.AdicionarFuncionario(func4);

            dp.ExibirTodos();

            dp.ExibirMaiorSalario();

            Console.WriteLine("Total da folha: " + dp.CalcularFolha());
        }
    }
}
