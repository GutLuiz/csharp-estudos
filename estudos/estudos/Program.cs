using static estudos.exercicios.ex01;

namespace aula02;

public class program 
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Escreva uma palavra que seja polimedro");
        string palavraUsu = Console.ReadLine();

        Palindromo p = new Palindromo();

        p.funcao(palavraUsu);

    }
  
}