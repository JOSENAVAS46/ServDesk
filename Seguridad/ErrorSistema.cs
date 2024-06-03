namespace ServDesk.Seguridad
{
    public class ErrorSistema : IErrorSistema
    {
        public Exception MostrarError(string error)
        {
            throw new CustomException(error);
        }
    }
}
