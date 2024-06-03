using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServDesk.Bussines.Login.Usuario;
using ServDesk.Models;

namespace ServDesk.Controllers.Login
{
    [Route("api/v1/usuarios")]
    [ApiController]
    public class UsuarioControlller : ControllerBase
    {

        private readonly OperadorUsuario _operadorUsuario;

        public UsuarioControlller(OperadorUsuario operadorUsuario)
        {
            _operadorUsuario = operadorUsuario;
        }

        [EnableCors]
        [HttpGet("clientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var result = await _operadorUsuario.ObtenerUsuariosPorRol("CLT");
            return Ok(result);
        }
        [EnableCors]
        [HttpGet("tecnicos")]
        public async Task<IActionResult> ObtenerTecnicos()
        {
            var result = await _operadorUsuario.ObtenerUsuariosPorRol("TNC");
            return Ok(result);
        }

        [EnableCors]
        [HttpGet("porcodigo")]
        public async Task<IActionResult> ObtenerUsuarioPorCodigo(string Codigo)
        {
            var result = await _operadorUsuario.ObtenerUsuarioPorCodigo(Codigo);
            return Ok(result);
        }

        [EnableCors]
        [HttpGet("porcedula")]
        public async Task<IActionResult> ObtenerUsuarioPorCedula(string Cedula)
        {
            var result = await _operadorUsuario.ObtenerUsuarioPorCedula(Cedula);
            return Ok(result);
        }


        [EnableCors]
        [HttpPost("cliente")]
        public async Task<IActionResult> CrearCliente([FromBody]UsuarioModel model)
        {
            await _operadorUsuario.CrearCliente(model);
            return Ok();
        }

        [EnableCors]
        [HttpPost("tecnico")]
        public async Task<IActionResult> CrearTecnico([FromBody] UsuarioModel model)
        {
            await _operadorUsuario.CrearTecnico(model);
            return Ok();
        }

    }
}
