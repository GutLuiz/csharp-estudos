using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static estudos.exercicios.ex14;
using static estudos.exercicios.ex19;

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
        public class PedidoDto
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

            private static int _contagemCliente = 0;

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

            private static int _contagemId = 0;

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
            public int ObterEstoque()
            {
                return _estoque;
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

            private static int _contagemId = 0;

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
            public Cliente BuscarPorEmail(string email)
            {
                foreach(Cliente c in _c)
                {
                    if(c.ObterEmail() == email)
                    {
                       return c;
                    }
                }
                return null;
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
            public Produto BuscarPorNome(string nome)
            {
                foreach (Produto p in _p)
                {
                    if (p.ObterNome() == nome)
                    {
                        return p;
                    }
                }
                return null;
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
        public class ClienteService
        {
            ClienteRepository _clienteRepository;

            public ClienteService(ClienteRepository repository) 
            {
                _clienteRepository = repository;
            }

            public void CadastrarCliente(ClienteDto dto)
            {
                if(dto.Nome == "")
                {
                    Console.WriteLine("Nome nao pode ser nulo");
                    return;
                }
                else if(dto.Email == "" && !dto.Email.Contains("@"))
                {
                    Console.WriteLine("Email invalido!");
                    return;
                }
                else if(dto.Telefone == "")
                {
                    Console.WriteLine("Telefone nao pode ser nulo");
                    return;
                }
                else
                {
                    Cliente cliente = new Cliente(dto.Nome, dto.Email, dto.Telefone);
                    _clienteRepository.Salvar(cliente);
                }
            }
            public List<Cliente> ListarClientes()
            {
                return _clienteRepository.BuscarTodos();
            }
        }
        
        public class ProdutoService
        {
            private ProdutoRepository _produtoRepository;

            public ProdutoService(ProdutoRepository repository)
            {
                _produtoRepository = repository;
            }

            public void CadastrarProduto(ProdutoDto dto)
            {
                if (dto.Nome == "")
                {
                    Console.WriteLine("Nome nao pode ser nulo");
                    return;
                }
                else if (dto.Preco <= 0)
                {
                    Console.WriteLine("Preco invalido!");
                    return;
                }
                else if (dto.Estoque <= 0)
                {
                    Console.WriteLine("Estoque invalido");
                    return;
                }
                Produto produto = new Produto(dto.Nome, dto.Preco, dto.Estoque);
                _produtoRepository.Salvar(produto);
            }
            public List<Produto> ListarProduto()
            {
                return _produtoRepository.BuscarTodos();
            }
        }
        public class PedidoService
        {
            private ClienteRepository _clienteRepository;
            private ProdutoRepository _produtoRepository;

            public PedidoService(ClienteRepository repository, ProdutoRepository repository1)
            {
                _clienteRepository = repository;
                _produtoRepository = repository1;
            }

            public Pedido CriarPedido(PedidoDto dto)
            {
                var cliente = _clienteRepository.BuscarPorEmail(dto.EmailCliente);
                if (cliente == null)
                {
                    Console.WriteLine("Cliente não encontrado");
                    return null;
                }

                var pedido = new Pedido(cliente);

                
                foreach (ItemPedidoDto i in dto.Ip)
                {
                    var produto = _produtoRepository.BuscarPorNome(i.NomeProduto);

                    if (produto == null)
                    {
                        Console.WriteLine("Produto não encontrado: " + i.NomeProduto);
                        return null;
                    }

                    // valida se tem estoque suficiente
                    if (produto.ObterEstoque() < i.Quantidade)
                    {
                        Console.WriteLine("Estoque insuficiente: " + i.NomeProduto);
                        return null;
                    }

                    // cria o item e adiciona no pedido
                    var item = new ItemPedido(produto, i.Quantidade);
                    pedido.AdicionarItem(item);

                    // atualiza o estoque do produto
                    _produtoRepository.AtualizarEstoque(produto, produto.ObterEstoque() - i.Quantidade);
                }

                return pedido;
            }
        }
        public void Executar() 
        {
            ClienteRepository cli = new ClienteRepository();
            ProdutoRepository prd = new ProdutoRepository();

            ClienteService clis = new ClienteService(cli);
            ProdutoService prds = new ProdutoService(prd);
            PedidoService pdds = new PedidoService(cli, prd);

            ClienteDto cliente1 = new ClienteDto{ Nome = "Gustavo", Email = "Luizgut@gmail.com", Telefone = "12345"};
            ClienteDto cliente2 = new ClienteDto { Nome = "KAUE", Email = "KAUE@gmail.com", Telefone = "1222345" };
            ClienteDto cliente3 = new ClienteDto { Nome = "Pitoco", Email = "Pitoco@gmail.com", Telefone = "1233225"};

            ProdutoDto produto1 = new ProdutoDto { Nome = "Microfone", Estoque = 10, Preco = 160m };
            ProdutoDto produto2 = new ProdutoDto { Nome = "teclado", Estoque = 20, Preco = 260m };
            ProdutoDto produto3 = new ProdutoDto { Nome = "monitor", Estoque = 2, Preco = 860m };
            ProdutoDto produto4 = new ProdutoDto { Nome = "fone", Estoque = 40, Preco = 60m };

            PedidoDto pedido1 = new PedidoDto();

            clis.CadastrarCliente(cliente1);
            clis.CadastrarCliente(cliente2);
            clis.CadastrarCliente(cliente3);

            prds.CadastrarProduto(produto1);
            prds.CadastrarProduto(produto2);
            prds.CadastrarProduto(produto3);
            prds.CadastrarProduto(produto4);

            PedidoDto pedidoValido = new PedidoDto
            {
                EmailCliente = "Luizgut@gmail.com",
                Ip = new List<ItemPedidoDto>
                {
                    new ItemPedidoDto { NomeProduto = "Microfone", Quantidade = 2 },
                    new ItemPedidoDto { NomeProduto = "teclado", Quantidade = 1 }
                }
            };

            var p1 = pdds.CriarPedido(pedidoValido);

            if (p1 != null)
            {
                p1.AlterarStatus("Aprovado");
                Console.WriteLine("\nPedido válido criado:");
                Console.WriteLine(p1);
            }

            PedidoDto pedidoInvalido = new PedidoDto
            {
                EmailCliente = "KAUE@gmail.com",
                Ip = new List<ItemPedidoDto>
                {
                    new ItemPedidoDto { NomeProduto = "monitor", Quantidade = 10 } 
                }
            };

            var p2 = pdds.CriarPedido(pedidoInvalido);

            if (p2 != null)
            {
                p2.AlterarStatus("Aprovado");
                Console.WriteLine("\nPedido inválido (não era pra acontecer):");
                Console.WriteLine(p2);
            }

            Console.WriteLine("\nCLIENTES:");
            foreach (var c in clis.ListarClientes())
            {
                Console.WriteLine($"Nome: {c.ObterNome()} | Email: {c.ObterEmail()}");
            }

            Console.WriteLine("\nPRODUTOS:");
            foreach (var p in prds.ListarProduto())
            {
                Console.WriteLine($"Nome: {p.ObterNome()} | Estoque: {p.ObterEstoque()}");
            }
        }
    }
}
