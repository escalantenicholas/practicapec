namespace pecanopractico.Models
{
    public class Trabajador
    {
        public string Dni { get; set; }
        public decimal HorasLaboradas { get; set; }
        public decimal DiasLaborados { get; set; }
        public decimal Faltas { get; set; }
        public int IdTipoTrabajador { get; set; }
    }
}
