namespace Estacionamento_Pare_Aqui  
{ 
        public class Ticket
    { 
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Ativo { get; set; }

        public Ticket() 
        { 
            Entrada = DateTime.Now;
            Ativo = true;
        }
        public double CalcularTempo()
        {
            TimeSpan tempoDecorrido = Saida - Entrada;
            return tempoDecorrido.TotalMinutes;
        }
        public double CalcularValor()
        {
            double valorPorMinuto = 0.09; // valor a ser cobrado por minuto
            double tempoDecorrido = CalcularTempo();
            return valorPorMinuto * tempoDecorrido;
        }
        public void MarcarSaida()
        {
            Saida = DateTime.Now;
            Ativo = false;
        }
    }

}