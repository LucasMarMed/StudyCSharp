namespace bytebank.Modelos.Conta
{
    public class ContaCorrente : IComparable<ContaCorrente>
    {

        public Cliente Titular { get; set; }
        public string Nome_Agencia { get; set; }

        private int _numero_agencia;
        public int Numero_agencia
        {
            get
            {
                return _numero_agencia;
            }
            set
            {
                if (value <= 0)
                {

                }
                else
                {
                    _numero_agencia = value;
                }
            }

        }

        private int _conta;
        public int Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if (value == 0)
                {
                    return;
                }
                else
                {
                    _conta = value;
                }
            }
        }

        private double saldo;
        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    saldo = value;
                }
            }
        }

        public bool Sacar(double valor)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            saldo = saldo + valor;
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                destino.saldo = destino.saldo + valor;
                return true;
            }
        }

        public int CompareTo(ContaCorrente? outro)
        {
            if (outro == null)
            {
                return 1;
            }
            else
            {
                return this.Conta.CompareTo(outro.Conta);
            }
        }

        public ContaCorrente(int numero_agencia)
        {
            Numero_agencia = numero_agencia;
            Random random = new() ;
            Conta = random.Next(10000,99999); 
            Titular = new Cliente();
            TotalDeContasCriadas += 1;

        }

        //public ContaCorrente(int numero_agencia) 
        //{
        //    Numero_agencia = numero_agencia;
        //    Conta = Guid.NewGuid().ToString().Substring(0, 8); Cria um numero de conta aleatorio, tipo string, com 8 caracteres
        //    Titular = new Cliente();
        //    TotalDeContasCriadas += 1;
        //}


        public static int TotalDeContasCriadas { get; set; }

        public override string ToString()
        {

            return $"\n === DADOS DA CONTA === \n" +
                   $"Número da Conta : {this.Conta} \n" +
                   $"Número da Agência : {this.Numero_agencia} \n" +
                   $"Saldo da Conta: {this.Saldo} \n" +
                   $"Titular da Conta: {this.Titular.Nome} \n" +
                   $"CPF do Titular  : {this.Titular.Cpf} \n" +
                   $"Profissão do Titular: {this.Titular.Profissao}\n\n"+
                   $"==============================\n";

        }
         private ContaCorrente()
        {

        } //Criado apenas para serialização do XML

    }

}