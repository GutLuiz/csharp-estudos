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
            private List<Produto> _prd;

            private decimal _total;
            private string _status;
            private string _data;

            public Pedido(string nome, string email, List<Produto> prd)
            {
                _nomeCliente = nome;
                _email = email;
                _prd = prd;
                _data = DateTime.Now.ToString("dd/MM/yyyy");

            }

            public void AdicionarProduto(Produto p)
            {
                _prd.Add(p);
            }
            public decimal ObterTotal()
            {
                return _total;
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
                if(dto.NomeCliente == "")
                {
                    Console.WriteLine("Nome do cliente nao pode ser vazio");
                    return null;
                }
                else if (!dto.Email.Contains("@")){
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
                    var pedido = new Pedido(dto.NomeCliente, dto.Email, new List<Produto>());



                    return pedido;
                }
            }
        }
    }
}
