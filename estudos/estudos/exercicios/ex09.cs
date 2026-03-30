using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace estudos.exercicios
{
    internal class ex09
    {
        public class Transacao
        {
            private string _tipo;
            private decimal _valor;
            private string _descricao;

            public Transacao(string tipo,decimal valor, string descricao)
            {
                _tipo = tipo;
                _valor = valor;
                _descricao = descricao;
            }

            public string ObterTipo()
            {
                return _tipo;
            }
            public decimal ObterValor()
            {
                return _valor;
            }
            public string ObterDescricao()
            {
                return _descricao;
            }
        }

        public class ContaBancaria
        {
            private string _titular;
            private decimal _saldo;
            private List<Transacao> _t = new List<Transacao>();
            public ContaBancaria(string titular, decimal saldo)
            {
                _titular = titular;
                _saldo = saldo;
            }
            public void Depositar(decimal valor, string descricao)
            {
                _saldo += valor;
                _t.Add(new Transacao("Deposito", valor, descricao));
            }
            public void Sacar(decimal valor, string descricao)
            {
                if(_saldo >= valor)
                {
                    _saldo -= valor;
                    _t.Add(new Transacao("Saque", valor, descricao));
                }
                else
                {
                    Console.WriteLine("Sem saldo!");
                }
            }
            public void ExibirExtrato()
            {
                foreach(Transacao transa in _t)
                {
                    string tipo = transa.ObterTipo();
                    decimal valor = transa.ObterValor();
                    string descricao = transa.ObterDescricao();

                    Console.WriteLine("Tipo da transacao: " + tipo + ", valor da transacao: " + valor + " e Descricao da transacao: " + descricao);
                }
                Console.WriteLine("Saldo atual: " + _saldo);
            }
            public void ExibirApenasDepositos()
            {
                foreach(Transacao transa in _t)
                {
                    if(transa.ObterTipo() == "Deposito")
                    {
                        decimal valor = transa.ObterValor();
                        string descricao = transa.ObterDescricao();
                        Console.WriteLine("Valor da transacao: " + valor + " e Descricao da transacao: " + descricao);
                    }
                }
            }
            public void ExibirApenasSaques()
            {
                foreach (Transacao transa in _t)
                {
                    if (transa.ObterTipo() == "Saque")
                    {
                        decimal valor = transa.ObterValor();
                        string descricao = transa.ObterDescricao();
                        Console.WriteLine("Valor da transacao: " + valor + " e Descricao da transacao: " + descricao);
                    }
                }
            }
        }
        public void Executar()
        {
            ContaBancaria conta = new ContaBancaria("Gustavo", 0m);

            conta.Depositar(500m, "Salário");
            conta.Depositar(100m, "Freelance");
            conta.Depositar(100m, "extra");
            conta.Sacar(200m, "Aluguel");

            conta.Sacar(1000m, "viagem");

            conta.ExibirExtrato();
            
            conta.ExibirApenasDepositos();
            conta.ExibirApenasSaques();
        }
    }
}
