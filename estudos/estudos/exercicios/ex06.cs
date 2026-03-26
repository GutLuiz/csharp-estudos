using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static estudos.exercicios.ex06;

namespace estudos.exercicios
{
    internal class ex06
    {
        public class Cliente
        {
            private string _nome;
            private string _email;
            private int _idade;
            private decimal _saldo_inicial;

            public Cliente (string nome, string email, int idade, decimal saldo)
            {
                _nome = nome;
                _email = email;
                _idade = idade;
                _saldo_inicial = saldo;
            }

            public string ObterNome() { return _nome; }
            public string ObterEmail() { return _email; }
            public int ObterIdade() { return _idade; }
            public decimal ObterSaldo() { return _saldo_inicial; }

        }

        public class ValidadorCliente
        {
            public bool ValidarNome(string nome)
            {
                if (nome == "")
                {
                    return false;
                }
                return true;
            }

            public bool ValidarEmail(string email)
            {
                if (!email.Contains("@"))
                {
                    return false;
                }
                return true;
            }

            public bool ValidarIdade(int idade)
            {
                if (idade < 18 || idade > 100)
                {
                    return false;
                }
                return true;
            }

            public bool ValidarSaldo(decimal saldo)
            {
                if(saldo < 0)
                {
                    return false;
                }
                return true;
            }
            public bool ValidarTudo(Cliente c)
            {
                ValidadorCliente v = new ValidadorCliente();
    
                if (v.ValidarNome(c.ObterNome()) && v.ValidarEmail(c.ObterEmail()) && v.ValidarIdade(c.ObterIdade()) && v.ValidarSaldo(c.ObterSaldo()))
                {
                    return true;
                }
                return false;
            }
        }
        public void Executar()
        {
            List<Cliente> clientes = new List<Cliente>();
            ValidadorCliente v = new ValidadorCliente();

            clientes.Add(new Cliente("Gustavo", "luizgut2016@gmail.com", 21, 550));
            clientes.Add(new Cliente("jose", "josegmail.com", 14, 50));
            clientes.Add(new Cliente("", "alisson@gmail.com", 31, 1550));

            foreach (Cliente c in clientes)
            {
                if (v.ValidarTudo(c))
                {
                    Console.WriteLine("Cadastro aceito");
                }
                else
                {
                    Console.WriteLine("Cadastro recusado");
                }
            }
        }
    }
}
