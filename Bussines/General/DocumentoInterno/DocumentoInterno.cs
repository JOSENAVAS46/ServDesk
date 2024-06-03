using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.General.DocumentoInterno
{
    public class DocumentoInterno : IDocumentoInterno
    {
        public SqlHelper? SqlHelper { get; set; }
        public IErrorSistema? ErrorSistema { get; set; }

        public async Task<DocumentoInternoModel> BuscarxCodigo(String Codigo)
        {
            return await SqlHelper.ConsultarAsync<DocumentoInternoModel>("ObtenerDocInterno", new { Codigo });
        }
        public async Task Actualizar(String Codigo)
        {
            await SqlHelper.EjecutarSpEscalarAsync("ActualizarDocInterno", new { Codigo });
        }

    
    }
}
