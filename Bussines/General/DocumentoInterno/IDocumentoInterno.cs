using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.General.DocumentoInterno
{
    public interface IDocumentoInterno
    {
        SqlHelper? SqlHelper { set; get; }
        IErrorSistema? ErrorSistema { set; get; }
        Task<DocumentoInternoModel> BuscarxCodigo(String Codigo);
        Task Actualizar(String coCodigodigo);

    }
}
