using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex17
    {

        public class ProdutoDto
        {
            public string Nome { get; set; } = "";
            public decimal Preco { get; set; } = 0;
            public int Quantidade { get; set; } = 0;
        }
        public class PedidoDto
        {
            public string NomeCliente { get; set; } = "";
            public string Email { get; set; } = "";
            public List<ProdutoDto> PrdDto;
        }
        public class Produto 
        {
            private string _nome;
            private decimal _preco;
            private int _quantidade;

            public Produto(string nome, decimal preco, int quantidade)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = quantidade;
            }
            public string ObterProduto()
            {
                return _nome;
            }
            public decimal ObterPreco()
            {
                return _preco;
            }
            public int ObterQuantidade()
            {
                return _quantidade;
            }
            
        }
        public class Pedido
        {
            private string _nomeCliente;
            private string _email;
            private List<Produto> _prd = new List<Produto>();

            private decimal _total;
            private string _status;
            private string _data;

            public Pedido(string nome, string email)
            {
                _nomeCliente = nome;
                _email = email;
                _status = "Aguardando Pagamento";
                _data = DateTime.Now.ToString("dd/MM/yyyy");
                _total = 0;

            }

            public string ObterStatus()
            {
                return _status;
            }

            public void AdicionarProduto(Produto p)
            {
                _prd.Add(p);
                _total += p.ObterPreco() * p.ObterQuantidade();
            }
     
            public void AlterarStatus(string status)
            {
                _status = status;
            }
            public override string ToString()
            {
                string pedido =  "Nome: " + _nomeCliente + ", Email: " + _email + ", total: " + _total + ", status: " + _status + ", data: " + _data; 
                foreach(Produto p in _prd)
                {
                    pedido +=  " Produto: " + p.ObterProduto() + ", Preco: " + p.ObterPreco() + ", Quantidade: " + p.ObterQuantidade();
                }
                return pedido;
            }
        }
        public class PedidoService
        {
            public Pedido CriarPedido(PedidoDto dto)
            {
                if (dto.NomeCliente == "")
                {
                    Console.WriteLine("Nome do cliente nao pode ser vazio");
                    return null;
                }
                else if (!dto.Email.Contains("@")) {
                    Console.WriteLine("O email precisa ter @");
                    return null;
                }
                else if (!dto.PrdDto.Any())
                {
                    Console.WriteLine("Sua lista de produtos esta vazia!");
                    return null;
                }
                else
                {

                    foreach (ProdutoDto p in dto.PrdDto)
                    {
                        if (p.Preco <= 0)
                        {
                            Console.WriteLine("Preco do produto tem que ser maior que 0.");
                            return null;
                        }
                        else if (p.Quantidade <= 0)
                        {
                            Console.WriteLine("Quantidade do produto tem que ser maior que 0");
                            return null;
                        }
                    }
                    var pedido = new Pedido(dto.NomeCliente, dto.Email);

                    foreach (ProdutoDto p in dto.PrdDto)
                    {
                        pedido.AdicionarProduto(new Produto(p.Nome, p.Preco, p.Quantidade));
                    }

                    return pedido;
                }
            }
            public void AprovarPedido(Pedido p)
            {
                p.AlterarStatus("Aprovado");
            }
            public void CancelarPedido(Pedido p)
            {
                p.AlterarStatus("Cancelado");
            }
            public void ExibirPedido(Pedido p)
            {
                Console.WriteLine(p.ToString());
            }
        }
        public void Executar()
        {
            var prd = new ProdutoDto
            {
                Nome = "arroz",
                Preco = 15m,
                Quantidade = 29
            };

            var prd01 = new ProdutoDto
            {
                Nome = "macarrao",
                Preco = 35m,
                Quantidade = 229
            };

            var prd001 = new ProdutoDto
            {
                Nome = "tomate",
                Preco = 5m,
                Quantidade = 5
            };

            var pdd = new PedidoDto
            {
                NomeCliente = "Gustavo",
                Email = "Gustavo@GMAIL.COM",
                PrdDto = new List<ProdutoDto>()
            };

            pdd.PrdDto.Add(prd);
            pdd.PrdDto.Add(prd01);
            pdd.PrdDto.Add(prd001);

            var prd2 = new ProdutoDto
            {
                Nome = "feijao",
                Preco = 25m,
                Quantidade = 129
            };

            var pdd2 = new PedidoDto
            {
                NomeCliente = "kaue",
                Email = "kaueGMAIL.COM",
                PrdDto = new List<ProdutoDto>()
            };

            pdd2.PrdDto.Add(prd2);

            var prd3 = new ProdutoDto
            {
                Nome = "carne",
                Preco = 0,
                Quantidade = 19
            };

            var pdd3 = new PedidoDto
            {
                NomeCliente = "jose",
                Email = "jose@GMAIL.COM",
                PrdDto = new List<ProdutoDto>()
            };

            pdd3.PrdDto.Add(prd3);

            var service = new PedidoService();

            var pedido1 = service.CriarPedido(pdd2);
            var pedido2 = service.CriarPedido(pdd3);
            var pedido3 = service.CriarPedido(pdd);

            service.AprovarPedido(pedido3);

            if (pedido1 != null) service.ExibirPedido(pedido1);
            if (pedido2 != null) service.ExibirPedido(pedido2);
            if (pedido3 != null) service.ExibirPedido(pedido3);
        }
    }
}
