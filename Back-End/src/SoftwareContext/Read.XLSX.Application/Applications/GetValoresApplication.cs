using Ganss.Excel;
using Read.XLSX.Application.Helpers;
using Read.XLSX.Domain.Contracts.Application;
using Read.XLSX.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Read.XLSX.Domain.Models.Opcoes;
using Microsoft.Extensions.Options;

namespace Read.XLSX.Application.Applications
{
    public class GetValoresApplication : IGetValoresApplication
    {
        private readonly Diretorio _diretorio;
        
        public GetValoresApplication(IOptions<Diretorio> options)
        {
            _diretorio = options.Value;
        }
        
        public async Task<List<IEnumerable<Pagamento>>> GetValoresXlsxAsync()
        {
            var usuarios = GetUsuariosDaTabela();
            var pagamentos = GetPagamentosDaTablela();

            var grid = Utils.GetPagamentos();
            
            var GridA = pagamentos.Where(e => e.Tipo == "Luz").ToList();
            var GridB = pagamentos.Where(e => e.Tipo == "Água").ToList();
            var GridC = pagamentos.Where(e => e.Tipo == "Internet").ToList();

            grid.Add(GridA);
            grid.Add(GridB);
            grid.Add(GridC);

            return await Task.FromResult(grid);
        }

        private IEnumerable<Usuario> GetUsuariosDaTabela()
        {
           return new ExcelMapper(_diretorio.LocalStorage).Fetch<Usuario>("Planilha1");
        }

        private List<Pagamento> GetPagamentosDaTablela()
        {
            var exelMapping = new ExcelMapper(_diretorio.LocalStorage);

            exelMapping.AddMapping<Pagamento>("Pagamento ID", e => e.Id);
            var retorno = exelMapping.Fetch<Pagamento>("Planilha2");
            return retorno.ToList();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var usuarios = new ExcelMapper(_diretorio.LocalStorage).Fetch<Usuario>("Planilha1").AsEnumerable();
            return await Task.FromResult(usuarios);
        }
    }
}
