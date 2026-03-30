using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex10
    {
        public class Produto
        {
            private string _produto;
            private decimal _preco;
            private string _categoria;

            public Produto(string produto, decimal preco, string categoria)
            {
                _produto = produto;
                _preco = preco;
                _categoria = categoria;
            }
            public string ObterProduto()
            {
                return _produto;
            }
            public decimal ObterPreco()
            {
                return _preco;
            }
            public string ObterCategoria()
            {
                return _categoria;
            }
        }
        public class Pedido
        {
            private int _pedido_id;
            private string _cliente;
            private List<Produto> _prd = new List<Produto>();
            private string _status;

            public Pedido(int pedidoId, string cliente)
            {
                _pedido_id = pedidoId;
                _cliente = cliente;
                _status = "Aberto";
            }

            public int ObterPedidoId()
            {
                return _pedido_id;
            }
            public string ObterCliente()
            {
                return _cliente;
            }
            public string ObterStatus()
            {
                return _status;
            }

            public void AdicionarProduto(Produto p)
            {
                if(_status == "Aberto")
                {
                    prd.Add(new Produto(p.ObterProduto(), p.ObterPreco(), p.ObterCategoria()));
                }
                else
                {
                    Console.WriteLine("Pedido fechado, não é possível adicionar produtos");
                }
            }
            public decimal CalcularTotal()
            {
                decimal total = 0;

                foreach(Produto p in prd)
                {
                    total += p.ObterPreco();
                }
                return total;
            }
            public void Fechar()
            {
                _status = "Fechado";
            }
            public void ExibirPedido()
            {
                Console.WriteLine("codigo: " + _pedido_id + ", cliente: " + _cliente);
                foreach(Produto p in prd) 
                {
                    string produto = p.ObterProduto();
                    string categoria = p.ObterCategoria();
                    decimal preco = p.ObterPreco();
                    Console.WriteLine("Produto: " + produto + ", Categoria: " + categoria + ", Preco: " + preco);
                }
                Console.WriteLine("Valor total Pedido: " + CalcularTotal());
            }
        }
        public class Restaurante
        {
            private  List<Pedido> _pdd = new List<Pedido>();

            public void AdicionarPedido(Pedido p)
            {
                _pdd.Add(p);
            }
            public void ExibirTodosPedidos()
            {
                foreach(Pedido p in _pdd)
                {
                    p.ExibirPedido();
                }
            }
            public void ExibirPedidosFechados()
            {
                foreach (Pedido p in _pdd)
                {
                    if(p.ObterStatus() == "Fechado")
                    {
                        p.ExibirPedido();
                    }
                }
            }
            public decimal CalcularFaturamento()
            {
                decimal total = 0;

                foreach(Pedido p in _pdd)
                {
                    total += p.CalcularTotal();
                }
                return total;
            }
        }
        public void Executar()
        {
            Pedido pdd1 = new Pedido(1, "julio");
            Produto prd1= new Produto("Frango", 50m, "proteina");
            Produto prd2 = new Produto("carne", 150m, "proteina");
            Produto prd3 = new Produto("tilapia", 250m, "proteina");
            pdd1.AdicionarProduto(prd1); 
            pdd1.AdicionarProduto(prd2);
            pdd1.AdicionarProduto(prd3); 

            Pedido pdd2 = new Pedido(2, "gustavo");
            Produto prd4 = new Produto("tomate", 10m, "verduras");
            Produto prd5 = new Produto("batata", 15m, "verduras");
            Produto prd6 = new Produto("couve", 25m, "verduras");
            pdd2.AdicionarProduto(prd4);
            pdd2.AdicionarProduto(prd5);
            pdd2.AdicionarProduto(prd6);


            Pedido pdd3 = new Pedido(3, "victor");
            Produto prd7 = new Produto("macarrao", 10m, "massa");
            Produto prd8 = new Produto("pastel", 15m, "massa");
            Produto prd9 = new Produto("raviole", 25m, "massa");
            pdd3.AdicionarProduto(prd7);
            pdd3.AdicionarProduto(prd8);
            pdd3.AdicionarProduto(prd9);

            Restaurante r = new Restaurante();
            r.AdicionarPedido(pdd1);
            r.AdicionarPedido(pdd2);
            r.AdicionarPedido(pdd3);

            pdd1.Fechar();
            pdd3.Fechar();

            pdd1.AdicionarProduto(prd2);

           
            r.ExibirTodosPedidos();
            r.ExibirPedidosFechados();
            Console.WriteLine("Faturamento: " + r.CalcularFaturamento()); 

        }
    }
}
