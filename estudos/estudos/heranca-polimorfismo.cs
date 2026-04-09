using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos
{
    internal class heranca
    {
        /*
           -> HERANÇA:  
            = É quando uma classe herda propriedades e métodos de outra. Você define o que é comum numa classe base, 
            e as classes filhas herdam tudo isso e adicionam o que é específico delas.
         */

        // exemplo:
        // classe base — o que é comum a todos
        public class Funcionario
        {
            protected string _nome;
            protected decimal _salario;

            public Funcionario(string nome, decimal salario)
            {
                _nome = nome;
                _salario = salario;
            }

            public virtual decimal CalcularSalario()
            {
                return _salario;
            }

            public override string ToString()
            {
                return "Nome: " + _nome + ", Salario: " + _salario;
            }
        }

        // classe filha — herda tudo e adiciona o que é seu
        public class Gerente : Funcionario
        {
            private int _tamanhoEquipe;

            public Gerente(string nome, decimal salario, int equipe)
                : base(nome, salario) // chama o construtor da classe base
            {
                _tamanhoEquipe = equipe;
            }

            public override decimal CalcularSalario()
            {
                return _salario + (_tamanhoEquipe * 100); // bônus por equipe
            }
        }

        public class Estagiario : Funcionario
        {
            private string _dataFimContrato;

            public Estagiario(string nome, decimal salario, string dataFim)
                : base(nome, salario)
            {
                _dataFimContrato = dataFim;
            }

            public override decimal CalcularSalario()
            {
                return _salario * 0.7m; // estagiário recebe 70%
            }
        }

        /*
          -> POLIMORFISMO:
            = Quando um método é virtual na base e override nas filhas, cada classe executa a sua própria versão:
       
        // exemplo:
        List<Funcionario> funcionarios = new List<Funcionario>();

        funcionarios.Add(new Gerente("Carlos", 5000m, 8));
        funcionarios.Add(new Estagiario("Ana", 1500m, "2024-12-31"));

        foreach (Funcionario f in funcionarios)
        {
            Console.WriteLine(f.CalcularSalario());
            // cada um calcula do seu jeito
            // Gerente   → 5000 + (8 * 100) = 5800
            // Estagiario → 1500 * 0.7 = 1050
        }
          */
    }
}
