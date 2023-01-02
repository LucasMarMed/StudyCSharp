using System;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Executando o projeto 10 - Calcula Poupança");

        double investimento = 1000;
        double rendimento = 0.005; // 0,5% ao mes 
        int tempo = 0;

        Console.WriteLine("Quantos meses voce pretende deixar seu dinheiro rendendo?");
        int mes = Convert.ToInt32(Console.ReadLine());

        while (tempo <= mes)
        {
            investimento = investimento + (investimento * rendimento);
            
            tempo++;
         }

        Console.WriteLine("Ao final de {0} meses seu patrimonio será de: R${1}", mes, investimento);
        Console.WriteLine("Tecle enter para fechar");
        Console.ReadLine();
    }
}