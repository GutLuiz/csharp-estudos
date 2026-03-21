using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex03
    {
        public class Aluno
        {
            private string _aluno;
            private decimal _nota1;
            private decimal _nota2;

            public Aluno(string aluno, decimal nota1, decimal nota2)
            {
                _aluno = aluno;
                _nota1 = nota1;
                _nota2 = nota2;
            }

            private decimal Media()
            {
                decimal media = (_nota1 + _nota2) / 2;
                return media;
            }

            public string ObterSituacao(decimal media)
            {
                string situacao = "";
                if(media >= 7)
                {
                     situacao = "Voce foi aprovado";
                }
                else if(media >= 5 && media < 7m)
                {
                    situacao = "voce ta de recuperacao";
                }
                else
                {
                    situacao = "voce ta reprovado";
                }
                return situacao;
            }

            public void Notas()
            {
                decimal media = Media();
                string situacao = ObterSituacao(media);
                Console.WriteLine(situacao);
            }

        }
        public void Executar()
        {
            Aluno a = new Aluno("Gustavo", 5.9m, 8.2m);

             a.Notas();
        }
    }
}
