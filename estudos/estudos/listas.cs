using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos
{
    internal class listas
    {
 
            /*
              -> LISTA:
               = Uma lista é uma coleção de itens do mesmo tipo que você pode adicionar, remover e percorrer.

               - Estrutura:
                    List<tipo> nomeDaLista = new List<tipo>();
             */


            public void Executar()
            {

                // lista vazia
                List<string> teste = new List<string>();
                // lista ja com valores
                List<int> notas = new List<int> { 1, 2, 3, 4, 5 };
                List<string> nomes = new List<string> { "carlos", "eduardo", "isabela" };

                // adicionando esses valores na lista:
                nomes.Add("joao");
                notas.Add(1);

                // eu posso acessar esses itens usando conchetes e a posicao deles [0] <- primeira posicao
                Console.WriteLine(nomes[0]);
                // posso ver a quantidade de itens que tem nessa lista
                Console.WriteLine(notas.Count);
                // posso ver o ultimo item da lista contando todos -1
                Console.WriteLine(nomes.Count - 1);

                // removendo itens 
                notas.Remove(1); // remove valor especifico 
                notas.Remove(0); // removendo pelo indice

                // podemos verificar se existe com CONTAINS
                bool temEssanota = notas.Contains(1);
                
                // O mais usado e percorrer essa lista com o foreach
                foreach(int nota in notas)
                {
                    Console.WriteLine("notas: " + nota);
                }

                // combinando com condicionais que e bastante comum tambem

                List<double> salarios = new List<double> { 1500, 3200, 800, 5000, 2100 };

                foreach (double salario in salarios)
                {
                    if(salario >= 2000)
                    {
                        Console.WriteLine(salario + " → Acima da média");
                    }
                    else 
                    {
                        Console.WriteLine(salario + " → Abaixo da média");
                    }
                }

                // outras operacoes:
                List<int> numeros = new List<int> { 4, 1, 8, 2, 6 };

                numeros.Sort();                        // ordena crescente: 1,2,4,6,8
                numeros.Reverse();                     // inverte: 8,6,4,2,1
                Console.WriteLine(numeros.Count);      // quantidade de itens
                numeros.Clear();                       // limpa a lista toda
                Console.WriteLine(numeros.Count);      // 0

            }
        }
    }


