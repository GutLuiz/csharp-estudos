using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex02
    {
        public class Calculadora
        {
            private int _numero1;
            private int _numero2;
            private decimal _decimal1;
            private decimal _decimal2;


            public Calculadora(int nmr1, int nmr2, decimal dcm1, decimal dcm2)
            {
                _numero1 = nmr1;
                _numero2 = nmr2;
                _decimal1 = dcm1;
                _decimal2 = dcm2;
            }

            public int SomarNumeros()
            {
                return _numero1 + _numero2;
            }

            public int SubtrairNumeros()
            {
                return _numero1 - _numero2;
            }

            public int MultiplicarNumeros()
            {
                return _numero1 * _numero2;
            }

            public decimal DividirDecimais()
            {
                if (_decimal2 == 0)
                {
                    return 0;
                }
                return _decimal1 / _decimal2;
            }
        }

        public void Executar()
        {
            Calculadora c = new Calculadora(1, 2, 3.2m, 4.2m);

            Console.WriteLine(c.SomarNumeros());
            Console.WriteLine(c.SubtrairNumeros());
            Console.WriteLine(c.MultiplicarNumeros());
            Console.WriteLine(c.DividirDecimais());
        }
    }
}
