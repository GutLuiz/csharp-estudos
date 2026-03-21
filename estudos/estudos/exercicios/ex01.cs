using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex01
    {
        public class Pessoa {
            private string _nome;
            private int _idade;
            private decimal _altura; 
            private bool _emprego ;
            private decimal _salario; 

            public Pessoa(string nome, int idade, decimal altura, decimal salario)
            {
                _nome = nome;
                _idade = idade;
                _altura = altura;
                _emprego = true;
                _salario = salario;
            }

           public void Dados()
            {
                Console.WriteLine("Meu nome e" + _nome + " tenho " + _idade + " de idade, " + _altura + " de altura e " + _salario + " de salario");
            }
        }
        public void Executar()
        {
            Pessoa p = new Pessoa("Gustavo", 21, 180m, 1000m);
            p.Dados();
        }

    }
}
