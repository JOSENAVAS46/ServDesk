using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.General.DocumentoInterno
{
    public class DocumentoInterno : IDocumentoInterno
    {
        public SqlHelper? SqlHelper { get; set; }
        public IErrorSistema? ErrorSistema { get; set; }

        public async Task<DocumentoInternoModel> BuscarxCodigo(string codigo)
        {
            return await SqlHelper.ConsultarAsync<DocumentoInternoModel>("ObtenerDocInterno", new { codigo });
        }
        public async Task Actualizar(string codigo)
        {
            await SqlHelper.EjecutarSpEscalarAsync("ActualizarDocInterno", new { codigo});
        }

    
    }
}
