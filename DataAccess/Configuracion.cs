namespace ServDesk.DataAccess
{
    public class Configuracion
    {
        public String SqlConnection { get; set; }

        public Configuracion(String _sqlConnection)
        {
            SqlConnection = _sqlConnection;
        }
    }
}
