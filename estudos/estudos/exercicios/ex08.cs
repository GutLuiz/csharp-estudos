using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex08
    {
        public class Produto
        {
            private string _nome;
            private decimal _preco;
            private int _estoque;


            public Produto(string nome, decimal preco, int estoque)
            {
                _nome = nome;
                _preco = preco;
                _estoque = estoque;
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
        }

        public class ItemCarrinho
        {
            private Produto _p;
            private int _quantidade;

            public ItemCarrinho(Produto p, int quantidade) 
            { 
                _p = p;
                _quantidade = quantidade;
            }

            public Produto ObterProduto()
            {
                return _p;
            }
            public int ObterQuantidade()
            {
                return _quantidade;
            }
        }

        public class Carrinho
        {
            private List<ItemCarrinho> itc = new List<ItemCarrinho>();

            public void AdicionarProduto(Produto p, int quantidade)
            {
                if (p.ObterEstoque() >= quantidade)
                {
                    itc.Add(new ItemCarrinho(p,quantidade));
                    Console.WriteLine("Produto adicionado!");
                    return;
                }
                Console.WriteLine("Produto sem estoque!");
            }
            public void RemoverProdutos(string NomeProduto)
            {
                itc.RemoveAll(item => item.ObterProduto().ObterNome() == NomeProduto);
            }
            public decimal CalcularTotal()
            {
                decimal total = 0;

                foreach (ItemCarrinho item in itc)
                {
                    total += item.ObterQuantidade() * item.ObterProduto().ObterPreco();
                }
                return total;
            }
            public void ExibirCarrinho()
            {
                foreach(ItemCarrinho item in itc)
                {
                    string nomeProduto = item.ObterProduto().ObterNome();
                    int quantidade = item.ObterQuantidade();
                    decimal subtotal = item.ObterQuantidade() * item.ObterProduto().ObterPreco();
                    Console.WriteLine(nomeProduto + ", " + quantidade + ", " + subtotal);
                }
                Console.WriteLine("Total do carrinho: " + CalcularTotal());
            }
        }
        public void Executar()
        {
            List<Produto> prd = new List<Produto>();

            prd.Add(new Produto("Teclado", 120m, 15));
            prd.Add(new Produto("mouse", 220m, 1));
            prd.Add(new Produto("microfone", 420m, 5));

            Carrinho c = new Carrinho();

            c.AdicionarProduto(prd[0], 45);
            c.AdicionarProduto(prd[1], 1);
            c.AdicionarProduto(prd[2], 4);

            c.ExibirCarrinho();
          
            c.RemoverProdutos("Teclado");

            c.ExibirCarrinho();
        }
    }
}
