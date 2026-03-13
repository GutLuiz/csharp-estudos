using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.conceitos
{
    public class metodos_retorno
    {
        /*
            -> Metodos: 
            = É um bloco de código com nome que executa uma tarefa. Em vez de repetir o mesmo código várias vezes, você escreve uma vez e chama pelo nome quando precisar. 
            
            - Return: No método com retorno, ele faz e te devolve um resultado pra você usar.
            == é como pedir pra alguém calcular o troco. Você passa o valor, ela calcula e te devolve o número. Agora você tem o resultado na mão pra fazer o que quiser com ele.
            
            - Estrutura:
                tipo NomeDoMetodo()
                {
                    return valor
                }
        */

        // devolve um int:
        public int Somar(int a, int b)
        {
            return a + b;
        }

        // devolvendo um double:
        public double CalcularMedia (double valor1, double valor2)
        {
            return (valor1 + valor2) / 2;
        }

        // devolvendo uma string:
        public string MontarNomeCompleto (string nome, string sobrenome)
        {
            return nome + " " + sobrenome;
        }
        
        // devolvendo um booleano
        public bool ClienteMaiorDeIdade (int idade)
        {
            return idade >= 18;
        }
    }

}
