using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Read.XLSX.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class XlsxController : ControllerBase
    {
        public async Task<ActionResult> GetValores()
        {
            
            
            return Ok();
        }
    }
}
