namespace pecanopractico.Models
{
    public class TipoTrabajador
    {
        public int IdTipoTrabajador { get; set; }
        public string NombreTipoTrabajador { get; set; }
        public decimal HoraLaborada { get; set; }
        public decimal Falta { get; set; }
        public decimal Bonificacion { get; set; }
        public double Impuesto { get; set; }
    }
}
