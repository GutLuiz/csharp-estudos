using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos
{
    internal class encapsulamento
    {
        /*
          -> ENCAPSULAMENTO:
              - É o princípio de esconder os detalhes internos de uma classe e expor só o que é necessário. A classe controla como seus dados são acessados e modificados.
            
         */
        public class ContaBancaria
        {
            private decimal _saldo;        // só a própria classe acessa
            protected decimal _limite;     // a classe e filhas acessam (herança - veremos depois)
            public string Titular;         // qualquer um acessa
        }

        public class Conta
        {
            public decimal Saldo; // qualquer um pode mudar diretamente
        }

        Conta c = new Conta();
        //c.Saldo = -99999m;  fraude sem validação nenhuma
        //c.Saldo = 999999m; 


        // solucao
        public class Conta1
        {
            private decimal _saldo; 

            // leitura — só deixa ver
            public decimal ObterSaldo()
            {
                return _saldo;
            }

            // escrita — passa pela validação
            public void Depositar(decimal valor)
            {
                if (valor <= 0)
                {
                    Console.WriteLine("Valor inválido");
                    return;
                }
                _saldo += valor; // só chega aqui se passou na validação
            }
        }

        Conta1 c1 = new Conta1();
        //c._saldo = -99999m; =  não compila — privado
        c1.Depositar(-99999m); 
    }
}
