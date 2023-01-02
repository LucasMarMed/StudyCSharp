using System;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Executando o projeto 12 - Investimento a Longo Prazo");

        double investimento = 1000;
        double rendimento = 1.005; // 0,5% ao mes 

        Console.WriteLine("Quantos meses voce pretende deixar seu dinheiro rendendo?");
        int mes = Convert.ToInt32(Console.ReadLine());
        
        

        for (int anos = 1; anos <= mes; anos += 12)
        {
            
            for (int tempo = 1; tempo <= mes; tempo++)
            {
                investimento *= rendimento;
                Console.WriteLine(investimento);
                
            }

            rendimento += 0.001;            
        }
      
        Console.WriteLine("Ao final de {0} meses seu patrimonio será de: R${1}", mes, investimento);
        Console.WriteLine("Tecle enter para fechar...");
        Console.ReadLine();
    }
}