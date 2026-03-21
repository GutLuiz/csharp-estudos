using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex04
    {
        public class Turma
        {
            // crio uma lista de alunos para adicionar mais de 1
            private List<Aluno> aluno = new List<Aluno>();

            // faco um metodo void para adicionar um aluno
            public void AdicionarAluno(string nome, decimal nota)
            {
                Aluno a = new Aluno(nome, nota);
                aluno.Add(a);
            }
            // faco uma condional para verificar a situacao de cada aluno
            public string ObterSituacao(decimal media)
            {
                string situacao = "";
                if (media >= 7)
                {
                    situacao = "aprovado";
                }
                else
                {
                    situacao = "reprovado";
                }
                return situacao;
            }
            
            // percorro cada aluno com um loop, e mostrando a o nomem, a nota e sua situacao(que tem que passar a nota pois a situcao precisa do parametro para fazer a validacao)
            public void ExibirTurma()
            {
                int aprovados = 0;
                int reprovados = 0;

                foreach(Aluno a in aluno)
                {
                    string situacao = ObterSituacao(a.ObterNota());
                    Console.WriteLine(a.ObterNome() + "tirou " + a.ObterNota() + "," + " esta" + situacao);

                    if (situacao == "aprovado")
                    {
                        aprovados++;
                    }
                    else
                    {
                        reprovados++;
                    }
                }
                Console.WriteLine("total aprovados:" + aprovados);
                Console.WriteLine("total reprovados:" + reprovados);
            }
        }
        // crio uma lista para popular os dados dos alunos que estao na turma
        public class Aluno
        {
            // propiedades dos alunos
            private string _nome;
            private decimal _nota;

            // construtor mostrando o que aluno precisa ter para ser adicionado ou qualquer coisa relacionado
            public Aluno(string nome, decimal nota)
            {
                _nome = nome;
                _nota = nota;
            }
            // retorno o nome de algum aluno
            public string ObterNome()
            {
                return  _nome;
            }
            // retorno a nota de algum aluno
            public decimal ObterNota()
            {
                return _nota;
            }
        }

        public void Executar()
        {
            // instancio a classe turma e adiciono os alunos
            Turma t = new Turma();

            t.AdicionarAluno("Gustavo", 7.8m);
            t.AdicionarAluno("jessica", 2.8m);
            t.AdicionarAluno("pedro", 4.8m);
            t.AdicionarAluno("juliana", 6.8m);
            t.AdicionarAluno("beatriz", 8.8m);

            t.ExibirTurma();
        }


    }
}
