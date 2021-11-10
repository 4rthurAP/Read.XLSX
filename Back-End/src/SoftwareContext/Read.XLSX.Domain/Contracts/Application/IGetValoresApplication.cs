using Read.XLSX.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.XLSX.Domain.Contracts.Application
{
    public interface IGetValoresApplication
    {
        Task<List<IEnumerable<Pagamento>>> GetValoresXlsxAsync();

        Task<IEnumerable<Usuario>> GetUsuariosAsync();
    }
}
