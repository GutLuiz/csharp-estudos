-> Contexto: Conceitos de while, for, foreach, continue, break

1 - O que são laços de repetição?
R = É codigo que fica repetindo uma tarefa, assim você não precisa ficar escrevendo a 
mesma coisa

2 - Quais são os tipos de laços de Repetição? e a Diferença entre eles?
R = Existem alguns tipos de loops, os mais importante são:
	- FOR: Ele faz esse loop, mas você precisa saber quantas vezes você vai repetir 
	aquela tarefa:
		-- exemplo:
			for(int i = 0; i < 5; i ++)
			{
				console.writeline("volta numero: " + i);
			}
			= Basicamente fazemos uma variavel (que muitas vezes é chamada I), colococamos
			o valor pra ela,fazemos uma "condicional" (no exemplo, faça essa tarefa
			se esse I for menor que 5) e depois fazemos a incrementação (toda vez que passar
			por esse i++ vai somar + 1 para esse int I) e no corpo é a sua tarefa que você 
			quer passar.
	- WHILE: É usada para repetir uma tarefa até uma condição mudar, diferente do laço FOR, 
	ele não precisa colocar um valor especifico na condição.
		-- exemplo:
			while(saldo > 200)
			{
				console.writeline("seu saldo esta otimo!")
			}
			= Basicamente ele vai ficar repetindo essa linha ate essa condicional não for
			verdadeira.
	- FOREACH: É usada quando você quer percorrer cada item de algum valor, principalmente
	lista.
		-- exemplo:
			List<string> nomes = new List<string>{"julio", "glauce", "neid"}
			foreach(string nome in nomes)
			{
				console.writeline("ola, " + nome);
			}
			= Basicamente colocamos o mesmo tipo de variavel com um nome qualquer e 
			usamos o IN pra usar por exemplo, essa lista. Assim conseguimos percorrer
			por cada item.

3 - Existem dentro desses loops alguns auxiliadores, quem são eles?
R = Temos alguns "Auxiliadores" que são o CONTINUE e o BREAK, o contine ele basicamente
pula aquela volta e continua para proxima. Já o break ele para o laço imediatamente
	-- exemplo:
		- break:
			for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break; // parou quando i for igual a 5
                }
            }
		- continue:
			for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    continue; // pulou o 5, continuou normalmente
                }
                Console.WriteLine(i);
            }



