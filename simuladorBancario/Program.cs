Conta? contaLogada;
List<Conta> contasCadastradas = new List<Conta>();
List<Transacao> transacoes = new List<Transacao>();

MenuLogin();

void MenuLogin()
{
    int opcaoEscolhida = 0;
    Console.WriteLine();
    Console.WriteLine($"===========================================");
    Console.WriteLine("1 - Entrar na conta");
    Console.WriteLine("2 - Criar uma conta");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha: ");
    Console.WriteLine();

    opcaoEscolhida = int.Parse(Console.ReadLine()!);

    do
    {
        switch (opcaoEscolhida)
        {
            case 1:
                EntrarNaConta();
                break;
            case 2:
                CriarConta();
                break;
            case 0:
                break;
            default:
                Console.WriteLine("Por favor, insira uma opção válida.");
                break;
        }
    } while (opcaoEscolhida != 0);
}

// Nao sei se era melhor colocar esse metodo inteiro dentro da classe conta ou deixar desse jeito
// ja que a main vai controlar o fluxo
void EntrarNaConta()
{
    Console.WriteLine("Digite seu email:");
    string email = Console.ReadLine()!;
    Console.WriteLine("Digite sua senha:");
    string senha = Console.ReadLine()!;

    if (Conta.IsContaCadastrada(contasCadastradas, email) == false)
    {
        Console.WriteLine("A conta informada não existe.");
        Console.WriteLine("Retornando para o menu de login...");
        Thread.Sleep(2000);
        return;
    }

    if (Conta.IsSenhaValida(contasCadastradas, senha) == false)
    {
        Console.WriteLine("Senha inválida.");
        Console.WriteLine("Retornando para o menu de login...");
        Thread.Sleep(2000);
        return;
    }
    
    contaLogada = Conta.EntrarNaConta(contasCadastradas, email, senha);
    Console.WriteLine("Login feito com sucesso!");
    ExibirMenu();
    
}

void CriarConta()
{
    Console.WriteLine("Digite seu nome:");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite seu cpf:");
    string cpf = Console.ReadLine()!;
    string email;

    do
    {
        Console.WriteLine("Digite seu email:");
        email = Console.ReadLine()!;

        if(Conta.IsContaCadastrada(contasCadastradas,email))
        {
            Console.WriteLine("Já existe uma conta cadastrada com esse email. Por favor tente outro");
        }
        
    } while (Conta.IsContaCadastrada(contasCadastradas,email));

    
    Console.WriteLine("Digite seu endereço:");
    string endereco = Console.ReadLine()!;
    Console.WriteLine("Digite sua senha:");
    string senha = Console.ReadLine()!;
    string confirmarSenha;

    do
    {
        Console.WriteLine("Confirme sua senha:");
        confirmarSenha = Console.ReadLine()!;

        if (confirmarSenha != senha)
        {
            Console.WriteLine("As senhas são diferentes, tente novamente.");
        }
    } while (confirmarSenha != senha);

    Cliente clienteNovo = new Cliente(nome, cpf, endereco);
    Conta contaNova = new Conta(clienteNovo, email, senha);

    contasCadastradas.Add(contaNova);
    Console.WriteLine("Conta cadastrada com sucesso!!");
    Console.WriteLine("Retornando para o menu de login...");
    Thread.Sleep(2000);
    MenuLogin();
}

void ExibirMenu(){
    int opcaoEscolhida;
    int valor;

    do
    {
        Console.WriteLine();
        Console.WriteLine($"===========================================");
        Console.WriteLine("1 - Transferir");
        Console.WriteLine("2 - Depositar");
        Console.WriteLine("3 - Sacar");
        Console.WriteLine("4 - Ver saldo");
        Console.WriteLine("5 - Ver informacoes da conta");
        Console.WriteLine("6 - Ver minhas Transacoes");
        Console.WriteLine("0 - Sair da conta");
        Console.Write("Escolha: ");
        Console.WriteLine();
        opcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (opcaoEscolhida)
        {
            case 0:
                contaLogada = null;
                MenuLogin();
                break;
            case 1:
                Console.WriteLine("Digite o email da conta para a qual voce deseja transferir: ");
                string email = Console.ReadLine()!;

                if (Conta.IsContaCadastrada(contasCadastradas, email) == false)
                {
                    Console.WriteLine("A conta informada não existe.");
                    Console.WriteLine("Retornando para o menu de login...");
                    Thread.Sleep(2000);
                    MenuLogin();
                }
                else
                {
                    Conta contaDestino = Conta.BuscarConta(contasCadastradas, email);

                    do
                    {
                        Console.WriteLine("Digite o valor que deseja transferir: ");
                        valor = int.Parse(Console.ReadLine()!);

                        if (valor < 0)
                        {
                            Console.WriteLine("O valor da transacao deve ser maior que zero.");
                        }

                    } while (valor < 0);

                    if (contaLogada!.Transferir(contaDestino, valor))
                    {
                        transacoes.Add(new Transacao(contaLogada, contaDestino, valor));
                    }
                }
                break;
            case 2:
                do
                {
                    Console.WriteLine("Digite o valor que deseja transferir: ");
                    valor = int.Parse(Console.ReadLine()!);

                    if (valor < 0)
                    {
                        Console.WriteLine("O valor da transacao deve ser maior que zero.");
                    }

                } while (valor < 0);

                if (contaLogada!.Depositar(valor)) {
                    transacoes.Add(new Transacao(contaLogada, contaLogada, valor));
                }
                break;
            case 3:
                do
                {
                    Console.WriteLine("Digite o valor que deseja transferir: ");
                    valor = int.Parse(Console.ReadLine()!);

                    if (valor < 0)
                    {
                        Console.WriteLine("O valor da transacao deve ser maior que zero.");
                    }

                } while (valor < 0);
                if (contaLogada!.Sacar(valor))
                {
                    transacoes.Add(new Transacao(contaLogada, contaLogada, valor));
                }
                break;
            case 4:
                contaLogada!.VerSaldo();
                break;
            case 5:
                contaLogada!.VerInformacoesDaConta();
                break;
            case 6:
                Transacao.VerTransacoes(transacoes, contaLogada!);
                break;
            default:
                Console.WriteLine("Por favor, insira uma opção válida.");
                break;
        }
    } while (opcaoEscolhida != 0);
    
}