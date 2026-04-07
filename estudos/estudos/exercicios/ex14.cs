using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex14
    {
        public class Produto
        {
            private string _nome;
            private int _codigo;
            private decimal _preco;
            private int _qntEstoque;

            public Produto(string nome, int codigo, decimal preco, int quantidadeEstoque)
            {
                _nome = nome;
                _codigo = codigo;
                _preco = preco;
                _qntEstoque = quantidadeEstoque;
            }

            public decimal ObterPreco()
            {
                return _preco;
            }
            public int ObterQuantidade()
            {
                return _qntEstoque;
            }

            public void Entrada(int quantidade)
            {
                _qntEstoque += quantidade;
            }
            public void Saida(int quantidade)
            {
                if (_qntEstoque >= quantidade)
                {
                    _qntEstoque -= quantidade;
                }
                else
                {
                    Console.WriteLine("Sem quantidade no estoque");
                }
            }
            public bool EstoqueAbaixoDe(int minimo)
            {
                if (_qntEstoque < minimo)
                {
                    return true;
                }
                return false;
            }
            public override string ToString()
            {
                return "Codigo: " + _codigo + ", Nome: " + _nome + ", Preco: " + _preco + " e quantidade: " + _qntEstoque;
            }
        }
        public class Estoque
        {
            private List<Produto> _p = new List<Produto>();

            public void AdicionarProduto(Produto p)
            {
                _p.Add(p);
            }
            public void ExibirTodos()
            {
                foreach(Produto p in _p)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            public void ExibirAbaixoDoMinimo(int minimo)
            {
                foreach(Produto p in _p)
                {
                    if(p.EstoqueAbaixoDe(minimo) == true )
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
            }
            public string ExibirMaisValioso()
            {
                Produto maiorPreco = null;

                foreach(Produto p in _p)
                {
                    if(maiorPreco == null || p.ObterPreco() > maiorPreco.ObterPreco())
                    {
                        maiorPreco = p;
                    }
                }
                return maiorPreco.ToString();
            }
            public decimal CalculcarValorTotalEstoque()
            {
                decimal total = 0;

                foreach (Produto p in _p)
                {
                    total += p.ObterPreco() * p.ObterQuantidade();
                }
                return total;
            }
        }
        public void Executar()
        {
            Produto p1 = new Produto("celular", 1, 2500m, 10);
            Produto p2 = new Produto("tv lg", 2, 3500m, 2);
            Produto p3 = new Produto("garrafa", 3, 500m, 12);
            Produto p4 = new Produto("camisa", 4, 50m, 14);
            Produto p5 = new Produto("short", 5, 20m, 25);

            Estoque e = new Estoque();

            e.AdicionarProduto(p1);
            e.AdicionarProduto(p2);
            e.AdicionarProduto(p3);
            e.AdicionarProduto(p4);
            e.AdicionarProduto(p5);

            p1.Saida(5);
            p5.Saida(20);
            p2.Entrada(40);
            p3.Entrada(1);

            p5.Saida(50);

            e.ExibirTodos();

            e.ExibirAbaixoDoMinimo(10);

            e.ExibirMaisValioso();

            Console.WriteLine("Valor total do estoque: " + e.CalculcarValorTotalEstoque());
        }
    }
}
