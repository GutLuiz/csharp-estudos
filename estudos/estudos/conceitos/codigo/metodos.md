-> Contextos: Conceitos de metodos voids, retornos, parametros, moficadores de acesso metodos
estaticos.

1 - O que é um metodo?
R = Ele é um bloco de codigo que executa uma tarefa especifica. Você define uma e vez
e chama quantas vezes quiser

2 - Como é esse bloco de codigo?
R = basicamente ele tem modificador (public, private, protected ou internal), 
o retorno (que pode ser void ou uma variavel, objetolista, dto etc.) o nome do metodo, 
parametros e o corpo.

-- exemplo: 

modificador retorno NomeDoMetodo(parâmetros)
{
    // corpo
}

3 - O que são esses modificadores de acesso?
R = Basicamente é quem pode chamar esse metodo :
    - public = qualquer pessoa acessa
    - private = só a própria classe acessa
    - protected = a classe e quem herda dela
    - internal = só dentro do projeto

4 - Quais são os tipos de retorno que eu posso fazer?
R = Basicamente tem dois tipos tipos de retorno, um que se chama void, onde você não precisa
retornar nada, somente executar e um que tem que retornar um valor, pode ser int, string,
bool etcc.

-- exemplos:
    == void:
        public void Somar(int a, int b)
        {
            resultado = a + b;
        }
    == return:
       public int Somar(int a, int b)
        {
            return a + b;
        }
5 - O que seria um metodo estatico? Qual é a diferença para um metodo normal?
R = O Metodo static pertence a classe, nao ao objeto, quando voce chama esse metodo não precisa
instanciar

-- exemplo:
    == metodo "normal":
    Calculadora calc = new Calculadora();
    calc.Somar(2, 3);
    == metodo static:
    double imposto = MinhaClasse.CalcularImposto(100);
    
        

