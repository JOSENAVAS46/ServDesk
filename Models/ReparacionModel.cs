namespace ServDesk.Models
{
    public class ReparacionModel
    {
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Estado { get; set; } 
        public DateTime FechaIngreso { get; set; }  
    }
}
