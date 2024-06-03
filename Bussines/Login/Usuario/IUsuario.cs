using ServDesk.Bussines.General.DocumentoInterno;
using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.Login.Usuario
{
    public interface IUsuario
    {
        SqlHelper? SqlHelper { set; get; }
        IErrorSistema? ErrorSistema { set; get; }
        IDocumentoInterno? DocInterno { get; set; }

        Task<List<UsuarioModel>> ObtenerUsuariosPorRol(String Rol);
        Task<UsuarioModel> ObtenerUsuarioPorCodigo(String Codigo);
        Task<UsuarioModel> ObtenerUsuarioPorCedula(String Cedula);
        Task<UsuarioModel> CrearTecnico(UsuarioModel Model);
        Task<UsuarioModel> CrearCliente(UsuarioModel Model);
    }
}
