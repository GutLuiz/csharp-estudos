using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static estudos.exercicios.ex18.ProdutoRepository;

namespace estudos.exercicios
{
    internal class ex18
    {
        public class ProdutoDto
        {
            public string Nome { get; set; } = "";
            public decimal Preco { get; set; } = 0;
            public string Categoria { get; set; } = "";
        }
        public class Produto
        {
            private int _id;
            private string _nome;
            private decimal _preco;
            private string _categoria;
            private string _dataCadastro;

            private static int _contadorId = 0;
            public Produto(string nome, decimal preco, string categoria)
            {
                _contadorId++;
                _id = _contadorId;
                _nome = nome;
                _preco = preco;
                _categoria = categoria;
                _dataCadastro = DateTime.Now.ToString("dd/MM/yyyy");
            }
            public int ObterId()
            {
                return _id;
            }
            public string ObterCategoria()
            {
                return _categoria;
            }
            public override string ToString()
            {
                return "id:" +  _id + ", Produto:" + _nome + ", Preco:" + _preco + ", categoria:" + _categoria;
            }
        }
        public class ProdutoRepository 
        {
            private List<Produto> _p = new List<Produto>();

            public void SalvarProduto(Produto p)
            {
                _p.Add(p);
            }
            public List<Produto> BuscarTodos()
            {
                return _p;
            }
            public Produto BuscarPorId(int id)
            {
                foreach(Produto p in _p)
                {
                    if (p.ObterId() == id)
                    {
                        return p;
                    }
                }
                return null;
            }
            public List<Produto> BuscarPorCategoria(string categoria)
            {
                List<Produto> produto = new List<Produto>();
                foreach(Produto p in _p)
                {
                    if(p.ObterCategoria() == categoria)
                    {
                        produto.Add(p);
                    }
                }
                return produto;
            }
            public void Deletar(int id)
            {
                _p.RemoveAll(p => p.ObterId() == id); 
            }

        }
        public class ProdutoService
        {
            private ProdutoRepository _repository;

            public ProdutoService(ProdutoRepository repository)
            {
                _repository = repository;
            }
            public void CriarProduto(ProdutoDto dto)
            {
                if (dto.Nome == "")
                {
                    Console.WriteLine("Nome nao pode ser nulo");
                    return;
                }
                else if (dto.Categoria == "")
                {
                    Console.WriteLine("Categoria nao pode ser nula");
                    return;
                }
                else if (dto.Preco == 0)
                {
                    Console.WriteLine("Preco nao pode ser 0");
                    return;
                }
                else
                {
                    Produto produto = new Produto(dto.Nome, dto.Preco, dto.Categoria);
                    _repository.SalvarProduto(produto);
                }
            }
            public void ListarTodos()
            {
                foreach (Produto p in _repository.BuscarTodos())
                {
                    Console.WriteLine(p.ToString());
                }
            }
            public void BuscarPorId(int id)
            {
                Console.WriteLine(_repository.BuscarPorId(id));
            }
            public void BuscarPorCategoria(string categoria)
            {
                foreach (Produto p in _repository.BuscarPorCategoria(categoria))
                {
                    Console.WriteLine(p.ToString());
                }
            }
            public void DeletarProduto(int id)
            {
                _repository.Deletar(id);
                Console.WriteLine("Produto deletado!");
            }
        }
        public void Executar()
        {
            ProdutoRepository repo = new ProdutoRepository();
            ProdutoService service = new ProdutoService(repo);

            ProdutoDto pdr1 = new ProdutoDto { Nome = "sacola", Preco = 15m, Categoria = "Plastico" };
            ProdutoDto pdr2 = new ProdutoDto { Nome = "Tenis", Preco = 25m, Categoria = "calcados" };
            ProdutoDto pdr3 = new ProdutoDto { Nome = "Camisa", Preco = 15m, Categoria = "Roupas" };
            ProdutoDto pdr4 = new ProdutoDto { Nome = "sorvete", Preco = 15m, Categoria = "comida" };
            ProdutoDto pdr5 = new ProdutoDto { Nome = "teclado", Preco = 45m, Categoria = "aparelho" };


            service.CriarProduto(pdr1);
            service.CriarProduto(pdr2);
            service.CriarProduto(pdr3);
            service.CriarProduto(pdr4);
            service.CriarProduto(pdr5);

            service.ListarTodos();

            service.BuscarPorId(5);

            service.BuscarPorCategoria("comida");

            service.DeletarProduto(5);

            service.ListarTodos();
        }
    }
}

