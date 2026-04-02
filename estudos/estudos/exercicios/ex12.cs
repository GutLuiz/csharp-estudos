using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex12
    {
        public class Cliente
        {
            private string _cliente;
            private int _cpf;
            private int _idade;

            public Cliente(string cliente, int cpf, int idade)
            {
                if(idade < 18)
                {
                    Console.WriteLine("Conta nao criada! menor de idade");
                }
                else
                {
                    _cliente = cliente;
                    _cpf = cpf;
                    _idade = idade;
                }
            }
            public string ObterCliente()
            {
                return _cliente;
            }
            public int ObterCpf()
            {
                return _cpf;
            }
            public int ObterIdade()
            {
                return _idade;
            }

        }
        public class Conta
        {
            private int _nConta;
            private Cliente _cliente;
            private decimal _saldo;
            private List<string> _transacoes = new List<string>();

            public Conta(int nConta, Cliente cliente, decimal saldo)
            {
                _nConta = nConta;
                _cliente = cliente;
                _saldo = saldo;
            }

            public decimal ObterSaldo()
            {
                return _saldo;
            }

            public void Depositar(decimal valor)
            {
                _saldo += valor;
                _transacoes.Add("Deposito de R$" + valor);
            }
            public bool Sacar(decimal valor)
            {
                if (_saldo >= valor)
                {
                    _saldo -= valor;
                    _transacoes.Add("Saque de R$" + valor);
                    return true;
                }
                else
                {
                    Console.WriteLine("Saldo menor que o valor do saque");
                    return false;
                }
            }
            public void Transferir(Conta destino, decimal valor)
            {
              
                if (Sacar(valor))
                {
                    destino.Depositar(valor);
                    destino._transacoes.Add("Transferencia recebida de R$" + valor);
                }
            }
            public void ExibirExtrato()
            {
                Console.WriteLine("Numero da conta" + _nConta + ", cliente: " + _cliente.ObterCliente() + ", Saldo atual: " + _saldo);
                foreach (string t in _transacoes)
                {
                    Console.WriteLine(t);
                }
            }
        }
        public class Banco
        {
            private string _nomeBanco;
            private List<Conta> _conta = new List<Conta>();

            public Banco(string banco)
            {
                _nomeBanco = banco;
            }

            public void AbrirConta(Conta c)
            {
                _conta.Add(c);
            }
            public void ExibirTodasContas()
            {
                foreach (Conta c in _conta)
                {
                    c.ExibirExtrato();
                }
            }
            public decimal ExibirTotalDepositos()
            {
                decimal total = 0;
                foreach (Conta c in _conta)
                {
                    total += c.ObterSaldo();
                }
                return total;
            }
        }
        public void Executar()
        {
            Cliente c1 = new Cliente("Gustavo", 123456789, 21);
            Conta cnt1 = new Conta(1, c1, 1500m);

            Cliente c2 = new Cliente("Julio", 123456739, 23);
            Conta cnt2 = new Conta(2, c2, 3500m);

            Cliente c3 = new Cliente("Victor", 123454789, 28);
            Conta cnt3 = new Conta(3, c3, 15000m);

            cnt1.Depositar(250m);
            cnt2.Depositar(150m);
            cnt3.Depositar(50m);

            cnt1.Sacar(250m);

            cnt3.Transferir(cnt1, 600m);

            Cliente c4 = new Cliente("carlos", 223456789, 15);

            Banco banco = new Banco("Banco inter");

            banco.AbrirConta(cnt1);
            banco.AbrirConta(cnt2);
            banco.AbrirConta(cnt3);

            banco.ExibirTodasContas();
            Console.WriteLine("Total do saldo das conta: " + banco.ExibirTotalDepositos());

        }
    }
}
