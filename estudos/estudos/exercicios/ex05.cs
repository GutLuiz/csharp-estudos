using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static estudos.exercicios.ex05;

namespace estudos.exercicios
{
    internal class ex05
    {
        public class Pedido
        {
            private int _id;
            private string _nome;
            private decimal _total;
            private string _status;

            public Pedido(int id, string nome, decimal total)
            {
                _id = id;
                _nome = nome;
                _total = total;
                _status = RegraStatus(total);
            }


            public string RegraStatus(decimal total)
            {
                string status = "";
                if(total < 100)
                {
                    status = "Pendente";
                }
                else if (total >= 100 && total < 499){
                    status = "Em processamento";
                }
                else
                {
                    status = "Aprovado automaticamente";
                }
                return status;
            }

            public void AplicarDesconto(decimal percentual)
            {
                _total = _total - (_total * percentual / 100);
                _status = RegraStatus(_total);
            }
            public void ExibirPedidos()
            {
                       
                    Console.WriteLine("Bem vindo ao relatorio do Pedido do id: " + _id);
                    Console.WriteLine("Nome do cliente do Pedido: " + _nome);
                    Console.WriteLine("total: " + _total);
                    Console.WriteLine("Status: " + _status);
            }

        }
        public void Executar()
        {
            List<Pedido> pdd = new List<Pedido>();

            pdd.Add(new Pedido(1, "Gustavo", 1500m));
            pdd.Add(new Pedido(2, "Jessica", 80m));
            pdd.Add(new Pedido(3, "Pedro", 300m));

            foreach(Pedido p in pdd)
            {
                p.ExibirPedidos();
            }
            pdd[0].AplicarDesconto(10m); 
            pdd[0].ExibirPedidos();

        }
    }
}
