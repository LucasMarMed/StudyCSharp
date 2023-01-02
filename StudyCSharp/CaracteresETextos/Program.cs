using System;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Projeto 5 - Caracteres e Texos");

        char letra = 'a';
        Console.WriteLine(letra);

        letra = (char)(69 + 1);
        Console.WriteLine(letra);

        letra = (char)(86 + 1);
        Console.WriteLine(letra);

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}