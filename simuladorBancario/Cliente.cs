public class Cliente
{
    public string Nome { get; }
    public string Cpf { get; }
   
    public string Endereco { get; }

    public Cliente(string nome, string cpf, string endereco)
    {
        this.Nome = nome;
        this.Cpf = cpf;
        this.Endereco = endereco;
    }
}