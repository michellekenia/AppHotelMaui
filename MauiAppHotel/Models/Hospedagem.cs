namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; } = null!;
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }
        public double ValorTotal
        {
            get
            {
                double valor_adultos = QntAdultos * (QuartoSelecionado?.ValorDiariaAdulto ?? 0);
                double valor_criancas = QntCriancas * (QuartoSelecionado?.ValorDiariaCrianca ?? 0);

                return (valor_adultos + valor_criancas) * Estadia;
            }
        }
    }
}