using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.General.DocumentoInterno
{
    public class OperadorDocumentoInterno
    {

        private readonly SqlHelper _sqlHelper;
        private readonly IErrorSistema _error;
        private readonly IDocumentoInterno _docInterno;

        public OperadorDocumentoInterno(SqlHelper sqlHelper, IErrorSistema error, IDocumentoInterno docInterno)
        {
            _sqlHelper = sqlHelper;
            _error = error;
            _docInterno = docInterno;
        }

        public async Task<DocumentoInternoModel> BuscarxCodigo(string codigo)
        {
            _docInterno.SqlHelper = _sqlHelper;
            return await _docInterno.BuscarxCodigo(codigo);
        }


    }
}
