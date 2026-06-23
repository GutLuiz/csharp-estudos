-> contexto: Classes, construtores, metodos, propriedades

1 - O Que são classes?
R = Classe é um molde, onde você pode colocar diversas regras, metodos,
propiedades metodos etc

2 - Quais são os pilares de uma classe?
R = Primeiro é a propiedades, onde são dados e suas caracteristicas dessa
classe (nome, saldo, idade), segundo é o construtor onde q é o que roda
quando criamos o obejto (define os valores iniciais) e os metodos que é
o que o objeto consegue fazer (sacar, depositar)

-- Exemplo propiedadases:
		private string Titular { get; set; }
        private decimal Saldo { get; set; }
        private bool Ativa { get; set; }
-- Exemplo construtor:
        public ContaBancaria(string titular, decimal saldo)
          {
              Titular = titular;
              Saldo = saldo;
              Ativa = true;
          }
-- Exemplo metodo:
        public void Depositar(decimal valor)
            {
                Saldo += valor;
                Console.WriteLine(Titular + " depositou " + valor + " | Saldo: " + Saldo);
            }

