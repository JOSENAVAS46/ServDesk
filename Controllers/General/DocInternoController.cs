using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServDesk.Bussines.General.DocumentoInterno;

namespace ServDesk.Controllers.General
{
    [Route("api/v1/docinterno")]
    [ApiController]
    public class DocInternoController : ControllerBase
    {
        
        private readonly OperadorDocumentoInterno _operadorDocumentoInterno;

        public DocInternoController(OperadorDocumentoInterno operadorDocumentoInterno)
        {
            _operadorDocumentoInterno = operadorDocumentoInterno;
        }

        [EnableCors]
        [HttpGet]
        public async Task<IActionResult> BuscarxCodigo(string codigo)
        {
            var result = await _operadorDocumentoInterno.BuscarxCodigo(codigo);
            return Ok(result);
        }

    }
}
