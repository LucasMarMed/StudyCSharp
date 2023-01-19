using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

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
    var contadoIgor = new ContaCorrente(956);
    contadoIgor.Depositar(200);
    var contadoIago = new ContaCorrente(956);
    contadoIago.Depositar(300);

    

    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(contadoIgor);
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(contadoIago);
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(new ContaCorrente(874));


    
    ContaCorrente conta = listaDeContas.MaiorSaldo();
    Console.WriteLine($"Conta com maior saldo: {conta.Conta}");

    listaDeContas.Remover( contadoIago );
    listaDeContas.ExibeLista();
    

}

// TestaArrayDeContasCorrentes();
#endregion

#region Usos do List: Add, Reverse, Count
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874),
//    new ContaCorrente(874),
//    new ContaCorrente(874)
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951),
//    new ContaCorrente(321),
//    new ContaCorrente(719)
//};

//_listaDeContas2.AddRange(_listaDeContas3);
//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = _listaDeContas3.GetRange(0, 2);
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");

//}
#endregion

#region

//ArrayList _listaDeContas = new ArrayList();
List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
    new ContaCorrente(874){Saldo=1000,Titular = new Cliente{Cpf="11111",Nome ="Eduardo"}},
    new ContaCorrente(874){Saldo=1200,Titular = new Cliente{Cpf="22222",Nome ="Allan"}},
    new ContaCorrente(874){Saldo=5100,Titular = new Cliente{Cpf="33333",Nome ="Caio"}}
};
AtendimentoCliente();

void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");

            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception ex)
            {

                throw new ByteBankException(ex.Message);
            }

            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverContas();
                    break;
                case '4':
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarConta();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }
    catch (ByteBankException ex)
    {

        Console.WriteLine($"{ex.Message}");
    }

}

void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia);

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }

void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não há contas cadastradas! ...");
            Console.ReadKey();
            return;
        }
        foreach (ContaCorrente item in _listaDeContas)
        {
            Console.WriteLine($"Titular da conta: {item.Titular.Nome}");
            Console.WriteLine($"CPF: {item.Titular.Cpf}");
            Console.WriteLine($"Profissão: {item.Titular.Profissao}");

            Console.WriteLine($"Número da conta: {item.Conta}");
            Console.WriteLine($"Agência: {item.Numero_agencia}");
            Console.WriteLine($"Saldo R$ {string.Format("{0:0.00}", item.Saldo)}");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }

    }

void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da Conta: ");

        int numeroConta = Convert.ToInt32(Console.ReadLine());
        ContaCorrente conta = null;

        foreach (var item in _listaDeContas)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
            }
        }
        if (conta != null)
        {
            _listaDeContas.Remove(conta);
            Console.WriteLine("... Conta removida da lista! ...");
        }
        else
        {
            Console.WriteLine(" ... Conta para remoção não encontrada ...");
        }
        Console.ReadKey();
    }

void OrdenarContas()
    {
        _listaDeContas.Sort();
        Console.WriteLine("... Lista de Contas ordenadas ...");
        Console.ReadKey();
    }

void PesquisarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===    PESQUISAR CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2) CPF TITULAR ou " +
        "(3) Nº AGÊNCIA: ");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.Write("Informe o número da Conta: ");
                int _numeroConta = Convert.ToInt32(Console.ReadLine());
                ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                Console.WriteLine(consultaConta.ToString());
                Console.ReadKey();
                break;
            }
        case 2:
            {
                Console.Write("Informe o CPF do Titular: ");
                string _cpf = Console.ReadLine();
                ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                Console.WriteLine(consultaCpf.ToString());
                Console.ReadKey();
                break;
            }

        case 3:
        {
            Console.Write("Informe o Nº da Agência: ");
            int _numeroAgencia = int.Parse(Console.ReadLine());
            var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
            ExibirListaDeContas(contasPorAgencia);
            Console.ReadKey();
            break;
        }
            default:
            Console.WriteLine("Opção não implementada.");
            break;
    }

    ContaCorrente ConsultaPorCPFTitular(string? cpf)
    {
        //ContaCorrente conta = null;
        //for (int i = 0; i < _listaDeContas.Count; i++)
        //{
        //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
        //    {
        //        conta = _listaDeContas[i];
        //    }
        //}
        //return conta;
        return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    }

    ContaCorrente ConsultaPorNumeroConta(int? numeroConta)
    {
        //ContaCorrente conta = null;
        //for (int i = 0; i < _listaDeContas.Count; i++)
        //{
        //    if (_listaDeContas[i].Conta.Equals(numeroConta))
        //    {
        //        conta = _listaDeContas[i];
        //    }
        //}
        //return conta;
        return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
    }
    

}

List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
{
    var consulta = (
                         from conta in _listaDeContas
                         where conta.Numero_agencia == numeroAgencia
                         select conta).ToList();
    return consulta;
}

void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
{
    if (contasPorAgencia == null)
    {
        Console.WriteLine(" ... A consulta não retornou dados ...");
    }
    else
    {
        foreach (var item in contasPorAgencia)
        {
            Console.WriteLine(item.ToString());
        }
    }
}





#endregion


//new ByteBankAtendimento().AtendimentoCliente();