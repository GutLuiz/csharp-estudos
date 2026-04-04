using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex13
    {
        public class Aluno
        {
            private string _nome;
            private int _matricula;
            private List<decimal> _notas = new List<decimal>();

           public Aluno(string nome,int matricula)
            {
                _nome = nome;
                _matricula = matricula;
                
            }

            public void AdicionarNota(decimal nota)
            {
                if(nota >= 0 && nota <= 10)
                {
                    _notas.Add(nota);
                }
            }
            public decimal CalcularMedia()
            {
                decimal media = 0;
                int quantidade = 0;

                foreach (decimal n in _notas)
                {
                    media += n;
                    quantidade++;
                }

                if(quantidade == 0)
                {
                    return 0;
                }

                return media / quantidade;
            }
            public string ObterSituacao()
            {
                if(CalcularMedia() >= 7)
                {
                    return ("Aprovado");
                }
                if(CalcularMedia() >= 5)
                {
                    return ("Recuperacao");
                }
                return ("reprovado");
            }
            public override string ToString()
            {
                return "Nome: " + _nome  + ", Matricula: " + _matricula + ", Media: " + CalcularMedia() + ", Situacao: " + ObterSituacao();
            }
        }
        public class Turma
        {
            private string _nomeTurma;
            private List<Aluno> _alunos = new List<Aluno>();

            public Turma(string nome)
            {
                _nomeTurma = nome;
            }

            public void AdicionarAluno(Aluno a)
            {
                _alunos.Add(a);
            }
            public void ExbirTodos()
            {
                foreach(Aluno a in _alunos)
                {
                   Console.WriteLine(a.ToString());
                }
            }
            public void ExibirAprovados()
            {
                foreach (Aluno a in _alunos)
                {
                        if (a.ObterSituacao() == "Aprovado")
                        {
                            Console.WriteLine(a);
                        }
                }
            }
            public string ExibirMelhorAluno()
            {
                Aluno Maiornota = null;

                foreach(Aluno a in _alunos)
                {
                    if(Maiornota == null || a.CalcularMedia() > Maiornota.CalcularMedia())
                    {
                        Maiornota = a;
                    }
                }
                return Maiornota.ToString();
            }

            public decimal CalcularMediaTurma()
            {
                decimal mediaTurma = 0;
                int quantidade = 0;

                foreach(Aluno a in _alunos)
                {
                    mediaTurma += a.CalcularMedia();
                    quantidade++;
                }
               return  mediaTurma / quantidade;
            }
        }
        public void Executar()
        {
            Aluno a1 = new Aluno("Gustavo", 12344455);
            Aluno a2 = new Aluno("jose", 123424455);
            Aluno a3 = new Aluno("julio", 222333);
            Aluno a4 = new Aluno("jessica", 1232244455);

            a1.AdicionarNota(8.5m);
            a1.AdicionarNota(4.5m);
            a1.AdicionarNota(3.5m);

            a2.AdicionarNota(3.5m);
            a2.AdicionarNota(2.5m);
            a2.AdicionarNota(1.5m);

            a3.AdicionarNota(6.5m);
            a3.AdicionarNota(7.5m);
            a3.AdicionarNota(2.5m);

            a4.AdicionarNota(18.5m);
            a4.AdicionarNota(6.5m);
            a4.AdicionarNota(5.5m);

            Turma t = new Turma("Ideal");

            t.AdicionarAluno(a1);
            t.AdicionarAluno(a2);
            t.AdicionarAluno(a3);
            t.AdicionarAluno(a4);

            t.ExbirTodos();

            t.ExibirAprovados();
          

          Console.WriteLine("Melhor aluno: " + t.ExibirMelhorAluno());

            Console.WriteLine("Media da turmna: " + t.CalcularMediaTurma());



        }

    }

}
