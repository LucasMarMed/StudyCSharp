using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
#nullable disable
    internal class ByteBankAtendimento
    {


        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(874){Saldo=1000,Titular = new Cliente{Cpf="11111",Nome ="Eduardo"}},
            new ContaCorrente(874){Saldo=1200,Titular = new Cliente{Cpf="22222",Nome ="Allan"}},
            new ContaCorrente(874){Saldo=5100,Titular = new Cliente{Cpf="33333",Nome ="Caio"}}
        };

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '7')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta      ===");
                    Console.WriteLine("===2 - Listar Contas        ===");
                    Console.WriteLine("===3 - Remover Conta        ===");
                    Console.WriteLine("===4 - Ordenar Contas       ===");
                    Console.WriteLine("===5 - Pesquisar Conta      ===");
                    Console.WriteLine("===6 - Exportar Contas      ===");
                    Console.WriteLine("===7 - Sair do Sistema      ===");
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
                        case '6':
                            ExportarContas();
                            break;
                        case '7':
                            EncerrarAplicacao();
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

        private void CadastrarConta()
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

            Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

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

        private void ListarContas()
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
                Console.WriteLine("=========================\n\n");
                Console.ReadKey();
            }

        }

        private void RemoverContas()
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
                if (item.Conta == numeroConta)
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

        private void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de Contas ordenadas ...");
            Console.ReadKey();
        }

        private void PesquisarConta()
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

                // return ( from conta in _listaDeContas          <==   Outra alternativa usando "SQL"
                //          where conta.Conta.Equals(numeroConta)
                //          select conta).FirstOrDefault();
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

        }

        private void ExportarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     EXPORTAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.Write("Deseja exportar para JSON (1) ou XML (2): ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        if (_listaDeContas.Count <= 0)
                        {
                            Console.WriteLine("... Não existe dados para exportação...");
                            Console.ReadKey();
                        }
                        else
                        {
                            string json = JsonConvert.SerializeObject(_listaDeContas, Newtonsoft.Json.Formatting.Indented);

                            try
                            {
                                FileStream fs = new FileStream("contas.json",
                                    FileMode.Create);
                                using (StreamWriter streamwriter = new StreamWriter(fs))
                                {
                                    streamwriter.WriteLine(json);
                                }
                                Console.WriteLine(@"Arquivo salvo em JSON!");

                            }
                            catch (Exception excecao)
                            {
                                throw new ByteBankException(excecao.Message);

                            }
                            Console.ReadKey();
                        }
                        break;
                    }
                case 2:
                    {
                        if (_listaDeContas.Count <= 0)
                        {
                            Console.WriteLine("... Não existe dados para exportação...");
                            Console.ReadKey();
                        }
                        else
                        {
                            var xml = new XmlSerializer(typeof(List<ContaCorrente>));

                            try
                            {
                                FileStream fs = new FileStream("contas.xml", FileMode.Create);
                                using (StreamWriter streamwriter = new StreamWriter(fs))
                                {
                                    xml.Serialize(streamwriter, _listaDeContas);
                                }
                                Console.WriteLine(@"Arquivo salvo em XML!");

                            }
                            catch (Exception excecao)
                            {
                                throw new ByteBankException(excecao.Message);

                            }
                            Console.ReadKey();
                        }
                            Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }

            
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando a aplicação ...");
            Console.ReadKey();
        }

    }

}