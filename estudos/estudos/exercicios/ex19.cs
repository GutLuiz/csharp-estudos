using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static estudos.exercicios.ex14;

namespace estudos.exercicios
{
    internal class ex19
    {
        public class ClienteDto
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
        }
        public class ProdutoDto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public int Estoque { get; set; }
        }
        public class PedidoDtos
        {
            public string EmailCliente { get; set; }
            public List<ItemPedidoDto> Ip { get; set; }
        }
        public class ItemPedidoDto
        {
            public string NomeProduto { get; set; }
            public int Quantidade { get; set; }
        }
        public class Cliente 
        {
            private int _id;
            private string _nome;
            private string _email;
            private string _telefone;
            private string _dataCadastro;

            private int _contagemCliente = 0;

            public Cliente(string nome, string email, string telefone)
            {
                _contagemCliente ++;
                _id = _contagemCliente;
                _nome = nome;
                _email = email;
                _telefone = telefone;
                _dataCadastro = DateTime.Now.ToString("dddd/MM/yyyy");
            }
            public string ObterNome()
            {
                return _nome;
            }
            public string ObterEmail()
            {
                return _email;
            }
        }
        public class Produto
        {
            private int _id;
            private string _nome;
            private decimal _preco;
            private int _estoque;
            private string _dataCadastro;

            private int _contagemId = 0;

            public Produto(string nome, decimal preco, int estoque)
            {
                _contagemId++;
                _id = _contagemId;
                _nome = nome;
                _preco = preco;
                _estoque = estoque;
                _dataCadastro = DateTime.Now.ToString("dddd/MM/yyyy");
            }
            public string ObterNome()
            {
                return _nome;
            }
            public decimal ObterPreco()
            {
                return _preco;
            }
            public void AtualizarEstoque(int estoque)
            {
                _estoque = estoque;
            }
        }
        public class ItemPedido 
        {
            private Produto _produto;
            private int _quantidade;
            private decimal _subtotal;

            public ItemPedido(Produto produto, int quantidade)
            {
                _produto = produto;
                _quantidade = quantidade;

                decimal valor = _produto.ObterPreco() * quantidade;
                _subtotal = valor;
            }
            public string ObterProduto()
            {
                return _produto.ObterNome();
            }
            public decimal ObterSubtotal()
            {
                return _subtotal;
            }
            public int ObterQuantidade()
            {
                return _quantidade;
            }
        }
        public class Pedido 
        {
            private int _id;
            private Cliente _cliente;
            private List<ItemPedido> _ip = new List<ItemPedido>();
            private decimal _totalCalculado;
            private string _status;
            private string _dataCriacao;

            private int _contagemId = 0;
            public Pedido(Cliente cliente)
            {
                _contagemId++;
                _id = _contagemId;
                _cliente = cliente;
                _totalCalculado = 0;
                _dataCriacao = DateTime.Now.ToString("dddd/MM/yyyy");
                _status = "Andamento";
            }
            public void AdicionarItem(ItemPedido item)
            {
                _ip.Add(item);
                _totalCalculado += item.ObterSubtotal();
            }
            public void AlterarStatus(string status)
            {
                _status = status;
            }
            public override string ToString()
            {
                var pedido = "Id: " + _id + ", Cliente: " + _cliente.ObterNome() + ", Total: " + _totalCalculado + ", Status: " + _status + ", data criacao: " + _dataCriacao;
                foreach (ItemPedido ip in _ip)
                {
                    pedido += " Produto: " + ip.ObterProduto() + ", SubTotal: " + ip.ObterSubtotal() + ", Quantidade: " + ip.ObterQuantidade();
                }
                return pedido;
            }
        }
        public class ClienteRepository
        {
            private List<Cliente> _c = new List<Cliente>();

            public void Salvar(Cliente c)
            {
                _c.Add(c);
            }
            public List<Cliente> BuscarPorEmail(string email)
            {
                List<Cliente> cEmail = new List<Cliente>();
                foreach(Cliente c in _c)
                {
                    if(c.ObterEmail() == email)
                    {
                        cEmail.Add(c);
                    }
                }
                return cEmail;
            }
            public List<Cliente> BuscarTodos()
            {
                return _c;
            }
        }
        public class ProdutoRepository
        {
            private List<Produto> _p = new List<Produto>();

            public void Salvar(Produto p)
            {
                _p.Add(p);
            }
            public List<Produto> BuscarPorNome(string nome)
            {
                List<Produto> pNome = new List<Produto>();
                    
                foreach(Produto p in _p)
                {
                    if(p.ObterNome() == nome)
                    {
                        pNome.Add(p);
                    }
                }
                return pNome;
            }
            public List<Produto> BuscarTodos()
            {
                return _p;
            }
            public void AtualizarEstoque(Produto p, int estoque)
            {
                p.AtualizarEstoque(estoque);
            }
        }
    }
}
