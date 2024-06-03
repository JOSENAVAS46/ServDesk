using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServDesk.Bussines.General;
using ServDesk.Bussines.General.DocumentoInterno;
using ServDesk.DataAccess;
using ServDesk.Models;
using ServDesk.Seguridad;

namespace ServDesk.Bussines.Login.Usuario
{
    public class Usuario : IUsuario
    {

        public SqlHelper? SqlHelper { get; set; }
        public IErrorSistema? ErrorSistema { get; set; }
        public IDocumentoInterno? DocInterno { get; set; }

        public async Task<List<UsuarioModel>> ObtenerUsuariosPorRol(String Rol)
        {
            return await SqlHelper.ListarAsync<UsuarioModel>("ObtenerUsuarioPorRol", new { Rol });
        }

        public async Task<UsuarioModel> ObtenerUsuarioPorCodigo(String Codigo)
        {
            return await SqlHelper.ConsultarAsync<UsuarioModel>("ObtenerUsuarioPorCodigo", new { Codigo });
        }

        public async Task<UsuarioModel> ObtenerUsuarioPorCedula(String Cedula)
        {
            return await SqlHelper.ConsultarAsync<UsuarioModel>("ObtenerUsuarioPorCedula", new { Cedula });
        }

        public async Task<UsuarioModel> CrearCliente(UsuarioModel model)
        {
            String tipo = "CLT";
            var doc = await DocInterno.BuscarxCodigo(tipo);
            int numero = doc.Numero + 1;
            model.Codigo = Utils.GenerateCode(tipo, numero);
            model.Rol = tipo;
            await SqlHelper.EjecutarSpEscalarAsync("CrearCliente", new
            {
                model.Codigo,
                model.Cedula,
                model.Nombre,
                model.UserName,
                model.Contrasena,
                model.Direccion,
                model.Telefono,
                model.CorreoElectronico,
                model.Rol

            });
            await DocInterno.Actualizar(tipo);
            return model;
        }

        public async Task<UsuarioModel> CrearTecnico(UsuarioModel model)
        {
            String tipo = "TNC";
            var doc = await DocInterno.BuscarxCodigo(tipo);
            int numero = doc.Numero + 1;
            model.Codigo = Utils.GenerateCode(tipo, numero);
            model.Rol = tipo;
            await SqlHelper.EjecutarSpEscalarAsync("CrearTecnico", new
            {
                model.Codigo,
                model.Cedula,
                model.Nombre,
                model.UserName,
                model.Contrasena,
                model.Direccion,
                model.Telefono,
                model.CorreoElectronico,
                model.Rol,
                model.Especialidad
            });
            await DocInterno.Actualizar(tipo);
            return model;
        }



    }
}
