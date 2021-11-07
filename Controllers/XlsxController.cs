using Microsoft.AspNetCore.Mvc;
using Read.XLSX.Domain.Contracts.Application;
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
        public async Task<ActionResult> GetValores()
        {
            return Ok(await _getValoresApplication.GetValoresXlsx());
        }
    }
}
