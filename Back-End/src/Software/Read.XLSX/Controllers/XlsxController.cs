using Microsoft.AspNetCore.Mvc;
using Read.XLSX.Domain.Contracts.Application;
using Read.XLSX.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.XLSX.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XlsxController : ControllerBase
    {
        private readonly IGetValoresApplication _getValoresApplication;
        public XlsxController(IGetValoresApplication getValoresApplication)
        {
            _getValoresApplication = getValoresApplication;
        }

        [HttpGet]
        public async Task<ActionResult<List<IEnumerable<Pagamento>>>> GetValores()
        {
            return Ok(await _getValoresApplication.GetValoresXlsxAsync());
        }
        
        [HttpGet("buscarUsuarios")]
        public async Task<ActionResult<List<IEnumerable<Pagamento>>>> GetUsuarios()
        {
            return Ok(await _getValoresApplication.GetUsuariosAsync());
        }
    }
}
