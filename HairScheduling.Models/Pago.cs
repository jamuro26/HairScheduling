namespace HairScheduling.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; } = DateTime.UtcNow;
        public string Estado { get; set; } = "Completado";
    }
}
