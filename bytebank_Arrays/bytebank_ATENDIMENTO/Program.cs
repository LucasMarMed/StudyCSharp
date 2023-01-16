using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Array
//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 42;
    idades[2] = 27;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idade}");
        acumulador += idade;
    }
    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
        //else
        //{
        //    Console.WriteLine($"Palavra não encontrada.");
        //}
    }
}

// código anterior omitido

//void TestaArrayDeContasCorrentes()
//{
//    ContaCorrente[] listaDeContas = new ContaCorrente[]
//    {
//        new ContaCorrente(874, "5679787-A"),
//        new ContaCorrente(874, "4456668-B"),
//        new ContaCorrente(874, "7781438-C")
//    };

//    for (int i = 0; i < listaDeContas.Length; i++)
//    {
//        ContaCorrente contaAtual = listaDeContas[i];
//        Console.WriteLine($"Índice {i} - Conta:{contaAtual.Conta}");
//    }
//}
void TestaArrayDeContasCorrentes()
{
    var contadoIgor = new ContaCorrente(956, "1111111");
    contadoIgor.Depositar(200);
    var contadoIago = new ContaCorrente(956, "8888888");
    contadoIago.Depositar(300);

    

    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(contadoIgor);
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(contadoIago);
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-2"));


    
    ContaCorrente conta = listaDeContas.MaiorSaldo();
    Console.WriteLine($"Conta com maior saldo: {conta.Conta}");

    listaDeContas.Remover( contadoIago );
    listaDeContas.ExibeLista();
    

}

// TestaArrayDeContasCorrentes();
#endregion




//new ByteBankAtendimento().AtendimentoCliente();