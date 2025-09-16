public class Transacao
{
    private DateTime Data { get; }
    private Conta Remetente { get; }
    private Conta Destinatario { get; }
    private int Valor { get; }

    public Transacao(Conta remetente, Conta destinatario, int valor)
    {
        Data = DateTime.Now;
        Remetente = remetente;
        Destinatario = destinatario;
        Valor = valor;
    }

    public static void VerTransacoes(List<Transacao> transacoes, Conta contaLogada)
    {
        foreach (Transacao transacao in transacoes.FindAll((transacao)=>transacao.Remetente == contaLogada))
        {
            Console.WriteLine();
            Console.WriteLine($"===========================================");
            Console.WriteLine($"Data: {transacao.Data}");
            Console.WriteLine($"Remetente: {transacao.Remetente.Titular.Nome}");
            Console.WriteLine($"Destinatario: {transacao.Destinatario.Titular.Nome}");
            Console.WriteLine($"Valor: {transacao.Valor}");
        }
    }


}