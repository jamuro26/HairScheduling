namespace HairScheduling.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public string? Notas { get; set; }
    }
}
