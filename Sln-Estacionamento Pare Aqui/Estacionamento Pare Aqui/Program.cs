using Estacionamento_Pare_Aqui;

List<Carro> carros = new List<Carro>();
{
    {
        int opcao = 0;
        do
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar Carro");
            Console.WriteLine("2 - Marcar Entrada");
            Console.WriteLine("3 - Marcar Saída");
            Console.WriteLine("4 - Consultar Historico");
            Console.WriteLine("5 - Sair");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarCarro();
                    break;
                case 2:
                    MarcarEntrada();
                    break;
                case 3:
                    MarcarSaida();
                    break;
                case 4:
                    ConsultarHistorico();
                    break;
                case 5:
                    Console.WriteLine("Obrigado por utilizar o Estacionamento Pare Aqui");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine();
        }
        while (opcao != 5);
    }
    void CadastrarCarro()
    {
        Carro carro = new Carro();

        Console.WriteLine("Digite a placa do carro");
        carro.Placa = Console.ReadLine();

        Console.WriteLine("Digite o modelo do carro");
        carro.Modelo = Console.ReadLine();

        Console.WriteLine("Digite a cor do carro");
        carro.Cor = Console.ReadLine();

        Console.WriteLine("Digite a marca do carro");
        carro.Marca = Console.ReadLine();

        carros.Add(carro);

        Console.WriteLine("Carro cadastrado com sucesso!");
    }
    void MarcarEntrada()
    {
        Console.WriteLine("Registrando entrada do veículo...");

        Console.WriteLine("Placa: ");
        string placa = Console.ReadLine();


        Carro carro = Carro.ObterCarro(placa, carros);

        if (carro == null)
        {
            Console.WriteLine("Carro não cadastrado!");
            return;
        }
        if (carro.TemTicketAtivo())
        {
            Console.WriteLine("Carro já possui ticket aberto");
            return;
        }
        carro.Tickets.Add(new Ticket());

        Console.WriteLine("Entrada registrada com sucesso!");
    }
    void MarcarSaida()
    {
        Console.WriteLine("Registrando saída do veículo...");

        Console.WriteLine("Placa: ");
        string placa = Console.ReadLine();

        Carro carro = Carro.ObterCarro(placa, carros);
        if (carro == null)
        {
            Console.WriteLine("Carro não cadastrado!");
            return;
        }

        Ticket ticketAtivo = carro.ObterTicketAtivo();

        if (ticketAtivo == null)
        {
            Console.WriteLine("Carro não possui ticket em aberto");
            return;
        }
        ticketAtivo.MarcarSaida();
        double valor = ticketAtivo.CalcularValor();

        Console.WriteLine($"Tempo de permanência:{ticketAtivo.CalcularTempo()} minutos");
        Console.WriteLine($"Valor cobrado: R$ {valor:F2}");

        Console.WriteLine("Saída registrada com sucesso!");
    }
    void ConsultarHistorico()
    {
        Console.WriteLine("Consultando o histórico do veículo...");

        Console.WriteLine("Placa: ");
        string placa = Console.ReadLine();

        Carro carro = Carro.ObterCarro(placa, carros);
        if (carro == null)
        {
            Console.WriteLine("Carro não possui histórico");
            return;
        }
        foreach (var ticket in carro.Tickets)
        {
            if (ticket.Ativo == true)
            {
                Console.WriteLine($"{ticket.Entrada} | -------------------- | {ticket.Ativo.ToString()} | R$--,--");
            }
            else
            {
                Console.WriteLine($"{ticket.Entrada} | {ticket.Saida} | {ticket.Ativo.ToString()} | R${ticket.CalcularValor()}");
            }
        }
    }
}
