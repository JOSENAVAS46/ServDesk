using ServDesk.Bussines.General.DocumentoInterno;
using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.Login.Usuario
{
    public class OperadorUsuario
    {

        private readonly SqlHelper _sqlHelper;
        private readonly IErrorSistema _error;
        private readonly IDocumentoInterno _documentoInterno;
        private readonly IUsuario _usuario;

        public OperadorUsuario(SqlHelper sqlHelper, IErrorSistema error, IDocumentoInterno documentoInterno, IUsuario usuario)
        {
            _sqlHelper = sqlHelper;
            _error = error;
            _documentoInterno = documentoInterno;
            _usuario = usuario;
        }

        public async Task<List<UsuarioModel>> ObtenerUsuariosPorRol(String Rol)
        {
            _usuario.SqlHelper = _sqlHelper;
            return await _usuario.ObtenerUsuariosPorRol(Rol);
        }

        public async Task<UsuarioModel> ObtenerUsuarioPorCodigo(String Codigo)
        {
            _usuario.SqlHelper = _sqlHelper;
            return await _usuario.ObtenerUsuarioPorCodigo(Codigo);
        }

        public async Task<UsuarioModel> ObtenerUsuarioPorCedula(String Cedula)
        {
            _usuario.SqlHelper = _sqlHelper;
            return await _usuario.ObtenerUsuarioPorCedula(Cedula);
        }


        public async Task CrearCliente(UsuarioModel Model)
        {
            try
            {
                _sqlHelper.IniciarTransaccion();
                _usuario.SqlHelper = _sqlHelper;
                _usuario.ErrorSistema = _error;
                _documentoInterno.SqlHelper = _sqlHelper;
                _documentoInterno.ErrorSistema = _error;

                _usuario.DocInterno = _documentoInterno;
                var cliente = await _usuario.CrearCliente(Model);
            }
            catch (Exception ex)
            {
                _sqlHelper.AbortarTransaccion();
                _error.MostrarError(ex.Message);
            }   
        }

        public async Task CrearTecnico(UsuarioModel Model)
        {
            try
            {
                _sqlHelper.IniciarTransaccion();
                _usuario.SqlHelper = _sqlHelper;
                _usuario.ErrorSistema = _error;
                _documentoInterno.SqlHelper = _sqlHelper;
                _documentoInterno.ErrorSistema = _error;

                _usuario.DocInterno = _documentoInterno;
                var cliente = await _usuario.CrearTecnico(Model);
            }
            catch (Exception ex)
            {
                _sqlHelper.AbortarTransaccion();
                _error.MostrarError(ex.Message);
            }
        }

    }
}
