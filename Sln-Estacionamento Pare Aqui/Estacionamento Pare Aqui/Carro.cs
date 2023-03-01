namespace Estacionamento_Pare_Aqui
{
    public class Carro

    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Carro()
        {
            Tickets = new List<Ticket>();
        }

        public Carro(string placa, string modelo, string cor, string marca)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            Marca = marca;
        }
        public bool TemTicketAtivo()
        {
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.Ativo)
                {
                    return true;
                }
            }
            return false;
        }
        public Ticket ObterTicketAtivo()
        {
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.Ativo)
                {
                    return ticket;
                }
            }
            return null;
        }
        public void AdicionarTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
        public void ImprimirHistorico()
        {
            foreach (Ticket ticket in Tickets)
            {
                Console.WriteLine($"Entrada{ticket.Entrada} - Saída: {ticket.Saida} - Valor: R${ticket.CalcularValor():F2}");
            }
        }
        public static Carro ObterCarro(string placa, List<Carro> carros)
        {
            foreach(Carro carro in carros)
            {
                if (carro.Placa == placa)
                {
                    return carro;
                }
            }
            return null;
        }
    }
}