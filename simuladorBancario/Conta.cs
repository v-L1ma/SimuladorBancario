public class Conta
{
    public Cliente Titular { get; }
    private double Saldo { get; set; }
    private double LimiteTransferencia { get; }
    private string Email { get; }
    private string Senha { get; }

    public Conta(Cliente titular, string email, string senha)
    {
        this.Titular = titular;
        this.Saldo = 0;
        this.LimiteTransferencia = 1500;
        this.Email = email;
        this.Senha = senha;
    }

    public static Boolean IsContaCadastrada(List<Conta> contasCadastradas, string email)
    {
        return contasCadastradas.Exists((conta) => conta.Email == email);
    } 

    public static Boolean IsSenhaValida(List<Conta> contasCadastradas, string senha)
    {
        return contasCadastradas.Exists((conta) => conta.Senha == senha);
    } 
    public static Conta EntrarNaConta(List<Conta> contasCadastradas, string email, string senha)
    {
        return contasCadastradas.Find((conta) => conta.Email == email && conta.Senha == senha)!;
    }
    public static Conta BuscarConta(List<Conta> contasCadastradas, string email)
    {
        return contasCadastradas.Find((conta) => conta.Email == email)!;
    }

    public Boolean Transferir(Conta contaDestino, int valor)
    {
        if (Saldo < valor)
        {
            Console.WriteLine("Saldo insuficiente.");
            return false;
        }

        if (valor > LimiteTransferencia)
        {
            Console.WriteLine($"O seu limite de transferencia é de apenas R$ {LimiteTransferencia}");
            return false;
        }

        Saldo -= valor;
        contaDestino.Saldo += valor;
        Console.WriteLine("Tranferência concluída com sucesso!");
        return true;
    }

    public Boolean Sacar(int valor)
    {
        if (Saldo < valor)
        {
            Console.WriteLine("Saldo insuficiente.");
            return false;
        }

        Saldo -= valor;
        Console.WriteLine("Saque concluído com sucesso!");
        return true;
    }

    public Boolean Depositar(int valor)
    {
        Saldo += valor;
        Console.WriteLine("Depósito concluído com sucesso!");
        return true;
    }

    public void VerSaldo()
    {
        Console.WriteLine($"O saldo atual é: {Saldo}");
    }

    public void VerInformacoesDaConta()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Exibindo informações da conta");
        Console.WriteLine("==============================");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Nome completo: {Titular.Nome}");
        Console.WriteLine($"CPF: {Titular.Cpf}");
        Console.WriteLine($"Endereço: {Titular.Endereco}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Senha: {Senha}");
    }
}