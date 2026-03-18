using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos
{
    internal class classesEObjetos
    {
        /*
          -> Classe e objetos:
           = Uma classe é um molde. Um objeto é o que você cria a partir desse molde.
           
           - Pilares de uma classe:
            == propiedades: os dados e as suas caracteristicas (nomes,saldo,idade)
            == construtor: e o que roda quando cria o objeto (define os valores inciais)
            == metodos: o que o objeto sabe fazer (sacar(), depositar())
         */

        public class ContaBancaria
        {

            // aqui sao as props
            private string Titular { get; set; }
            private decimal Saldo { get; set; }
            private bool Ativa { get; set; }

            // contrutor: que roda ao criar o objeto
            public ContaBancaria(string titular, decimal saldo)
            {
                Titular = titular;
                Saldo = saldo;
                Ativa = true;
            }
            
            //Metodos
            public void Depositar(decimal valor)
            {
                Saldo += valor;
                Console.WriteLine(Titular + " depositou " + valor + " | Saldo: " + Saldo);
            }

            public void Sacar(decimal valor)
            {
                if(valor > Saldo)
                {
                    Console.WriteLine("Saldo insuficiente");
                    return;
                }

                Saldo -= valor;
                Console.WriteLine(Titular + " sacou " + valor + " | Saldo: " + Saldo);
            }

            // para a outras classe lerem o saldo fora. 
            public decimal ObterSaldo()
            {
                return Saldo;
            }

            public string ObterTitular()
            {
                return Titular;
            }
        }
        public void Executar()
        {
            ContaBancaria ctb = new ContaBancaria("Carlos", 1000m);
            ctb.Depositar(200m);
            ctb.Sacar(100m);
            Console.WriteLine(ctb.ObterSaldo());
        }



    }
}
