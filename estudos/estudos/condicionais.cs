using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos
{
    internal class condicionais
    {
        /*
          -> Condicionais:
           = É o código tomando decisões. Dependendo de uma condição, ele segue um caminho ou outro.

          - estrutura:
           =  if(codicao)
              {
               executa se for true  
              }
              else
              {
                executa se for false
              } 
          - operadores para usar em condicionais:
            == igual 
            != diferente
            > maior que
            < menor que
            >= maior ou igual
            <= menor ou igual
            && E (as duas true)
            || OU (uma true basta)
            ! diferente
         */

        public void executar()
      {
        int idade = 20;

            if (idade >= 18)
            {
                Console.WriteLine("Maior de idade");
            }
            else 
            {
                Console.WriteLine("menor de idade");
            }

            double nota = 7.5;

            if (nota >= 9)
            {
                Console.WriteLine("Aprovado com excelência");
            }
            else if (nota >= 7)
            {
                Console.WriteLine("Aprovado");
            }
            else if (nota >= 5)
            {
                Console.WriteLine("Recuperação");
            }
            else
            {
                Console.WriteLine("Reprovado");
            }
        }

    }
}
