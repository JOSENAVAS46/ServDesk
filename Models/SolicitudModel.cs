﻿namespace ServDesk.Models
{
    public class SolicitudModel
    {
        public String Codigo { get; set; }
        public String Cliente { get; set; }
        public String Equipo { get; set; }
        public String Tecnico { get; set; }
        public String Tipo { get; set; }
        public String Descripcion { get; set; }
        public String Estado { get; set; }
        public DateTime FechaIngreso { get; set; }

    }
}
