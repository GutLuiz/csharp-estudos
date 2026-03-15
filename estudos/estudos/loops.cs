using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos
{
    internal class loops
    {
        /*
            -> lacos de repeticao:
             = É o código repetindo uma tarefa sem você precisar escrever a mesma coisa várias vezes.
            
            - existem alguns tipo de laco de repeticao, os mais importantes:
             = FOR: quando você sabe quantas vezes vai repetir
             = WHILE: quando você repete até uma condição mudar
             = FOREACH: quando você quer percorrer cada item de uma lista

            - continue ou break:
            = break: para o laco imediatamente.
            = continue: pula aquela volta e continua
            
         */

        public void executar()
        {
            // for: neste exemplo eu sei a quantiadade de vezes que vai repetir (5 vezes), por isso usamos o for:
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("volta numero: " + i);
            }
            // imprime: 0, 1, 2, 3, 4

            // contando de tras pra frente: usamos i--:
            for (int i = 1; i < 10; i--)
            {
                Console.WriteLine(i);
            }

            // while: eu preciso colocar uma condicao:
            int tentativas = 0;
            while (tentativas < 3)
            {
                Console.WriteLine("tentativa:" + tentativas);
                tentativas++;
            }

            // foreach: usado para percorrer uma lista por exemplo:
            List<string> nomes = new List<string> { "carlos", "juliana", "miguel" };
            foreach(string nome in nomes)
            {
                Console.WriteLine("ola," + nome);
            }

            //break

            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break; // parou quando i for igual a 5
                }
            }

            // continue:
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    continue; // pulou o 5, continuou normalmente
                }
                Console.WriteLine(i);
            }
        }
    }
}
