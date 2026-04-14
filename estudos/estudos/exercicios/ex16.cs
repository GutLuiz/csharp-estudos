

using static estudos.exercicios.ex16;

namespace estudos.exercicios
{
    internal class ex16
    {
        public class ClienteDto
        {
            public string Nome { get; set; } = "";
            public string Email { get; set; } = "";
            public int Idade { get; set; } = 0;
        }

        public class Cliente
        {
            private string _nome;
            private string _email;
            private int _idade;
            private string _dataCadastro;
            private string _status;

            public Cliente(string nome, string email, int idade)
            {
                _nome = nome;
                _email = email;
                _idade = idade;
                _dataCadastro = DateTime.Now.ToString("dd/MM/yyyy");
                _status = "Ativo";
            }

            public void RegraStatus(string status)
            {
                 _status = status;
            }
            public string ObterNome()
            {
                return _nome;
            }
            public string ObterEmail()
            {
                return _email;
            }
            public int ObterIdade()
            {
                return _idade;
            }
            public string ObterStatus()
            {
                return _status;
            }


        }
        public class ClienteService
        {
            public Cliente CriarCliente(ClienteDto dto)
            {
                if (dto.Nome == "")
                {
                    Console.WriteLine("Nome nao pode ser nulo");
                    return null;
                }
                else if (!dto.Email.Contains("@"))
                {
                    Console.WriteLine("Email precisa conter @");
                    return null;
                }
                else if (dto.Idade < 18 || dto.Idade > 100)
                {
                    Console.WriteLine("A idade precisa ser entre 18 a 100");
                    return null;
                }
                else
                {
                   return new Cliente(dto.Nome, dto.Email, dto.Idade);
                }
            }
            public void AtivarCliente(Cliente c)
            {
                c.RegraStatus("Ativo");
            }
            public void DesativarCliente(Cliente c)
            {
                c.RegraStatus("Inativo");
            }
            public void ExibirCliente(Cliente c)
            {
                Console.WriteLine("Cliente" + c.ObterNome() + ", Email: " + c.ObterEmail() + ", Idade: " + c.ObterIdade() + " e Status: " + c.ObterStatus());
            }
        }
        public void Executar()
        {
            ClienteDto dto1 = new ClienteDto();
            dto1.Nome = "Gustavo";
            dto1.Email = "gustavo@gmail.com";
            dto1.Idade = 21;

            ClienteDto dto2 = new ClienteDto();
            dto2.Nome = "kaue";
            dto2.Email = "kauegmail.com";
            dto2.Idade = 20;

            ClienteDto dto3 = new ClienteDto();
            dto3.Nome = "jose";
            dto3.Email = "jose@gmail.com";
            dto3.Idade = 25;


            ClienteService c = new ClienteService();

            Cliente cliente1 = c.CriarCliente(dto1);
            Cliente cliente2 = c.CriarCliente(dto2);
            Cliente cliente3 = c.CriarCliente(dto3);

            c.DesativarCliente(cliente3);

            if (cliente1 != null) c.ExibirCliente(cliente1);
            if (cliente2 != null) c.ExibirCliente(cliente2); 
            if (cliente3 != null) c.ExibirCliente(cliente3);

        }
    }
}
