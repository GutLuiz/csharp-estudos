using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.conceitos
{
    internal class metodos_void
    {
        /*
       -> Metodos: 
       = É um bloco de código com nome que executa uma tarefa. Em vez de repetir o mesmo código várias vezes, você escreve uma vez e chama pelo nome quando precisar.

       - Void:
       = void significa que o método faz alguma coisa, mas não devolve nada. Ele age, mas não responde.
       == é como mandar alguém ligar a luz. A pessoa vai lá e liga. Ela não te devolve nada, só executou a tarefa.

       - estrutura: 
          void NomeDoMetodo()
          {
             acao
          }

       - Para chamar o metodo:
         NomeDoMetodo() 
     */

        public void ExibirBoasVindas()
        {
            Console.WriteLine("Boas vindas gustavo");
        }

        // Metodos com parametos:
        // parametros sao informacoes que voce passa pro metodo trabalhar

        public void ExibirNome(string nome)
        {
            Console.WriteLine("Ola," + nome);
        }

        public void ExibirIdade(string nome, int idade)
        {
            Console.WriteLine(nome + " tem " + idade + "anos");
        }


        // metodo com uma logica condicional:
        public void VerificarIdade(int idade)
        {
            if(idade >= 18)
            {
                Console.WriteLine("maior de idade!");
            }
            else
            {
                Console.WriteLine("menor idade");
            }
        }
        // obs: importante sempre adicionar parametros para informacoes distintas e colocar informacoes dos parametros na mesma ordem que foi colocada.
    }
}
