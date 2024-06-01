namespace ServDesk.Models
{
    public class Usuario
    {
        public String Codigo { get; set; }
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String UserName { get; set; }
        public String Contrasena { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String CorreoElectronico { get; set; }
        public String Rol { get; set; }
        public String? Especialidad { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaIngreso { get; set; }

    }
}
