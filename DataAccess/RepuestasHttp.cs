namespace ServDesk.DataAccess
{
    public class RepuestasHttp
    {
        public String StatusCode { get; set; }
        public object Data { get; set; }

    }

    public enum HttpMethods
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
