namespace HairScheduling.Models
{
    public class DetalleCita
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public int ServicioId { get; set; }
        public decimal Precio { get; set; }
    }
}
