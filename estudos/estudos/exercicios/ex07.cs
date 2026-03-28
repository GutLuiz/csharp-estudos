using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex07
    {
        public class Usuario
        {
            private string _nome;
            private string _email;
            private string _senha;
            public bool _bloqueado;
            public int _tentativas_login;

            public Usuario(string nome, string email, string senha)
            {
                _nome = nome;
                _email = email;
                _senha = senha;
                _bloqueado = false;
                _tentativas_login = 0;
            }

            public string ObterNome()
            {
                return _nome;
            }
            public string ObterEmail()
            {
                return _email;
            }
            public string ObterSenha()
            {
                return _senha;
            }
            public void Bloquear()
            {
                _bloqueado = true;
            }
            public int ObterTentativas()
            {
                return _tentativas_login;
            }
            public bool ObterBloqueio()
            {
                return _bloqueado;
            }

            public void ZerarTentativas()
            {
                _tentativas_login = 0;
            }
            public void IncrementarTentativas()
            {
                _tentativas_login++;
            }
        }

        public class Autenticador
        {
            public bool Login(Usuario u, string senhaDigitada)
            {
                if(u.ObterSenha() != senhaDigitada)
                {
                    return false;  
                }
                return true;
            }
            public void Bloquear(Usuario u)
            {
                 u.Bloquear();
            }
            public void TentativaFalha(Usuario u)
            {
                u.IncrementarTentativas();
                if (u.ObterTentativas() == 3)
                {
                    Bloquear(u);
                }
      
            }
            public void VerificarAcesso(Usuario u, string senhaDigitada)
            {
               
                if (u.ObterBloqueio())
                {
                    Console.WriteLine("Usuario bloqueado");
                    return;
                }
                if (Login(u, senhaDigitada))
                {
                    Console.WriteLine("Acesso permitido");
                    u.ZerarTentativas();
                }
                else
                {
                   
                    TentativaFalha(u);
                    Console.WriteLine(u.ObterTentativas());
                }
             
                
            }

            public void Executar()
            {
                List<Usuario> u = new List<Usuario>();

                u.Add(new Usuario("Luiz gustavo", "luizgut2016@gmail.com", "123"));
                u.Add(new Usuario("Luiz", "luizgut2016@gmail.com", "1234"));

                VerificarAcesso(u[0], "123");
                VerificarAcesso(u[1], "133333");
            }
        }
    }
}
