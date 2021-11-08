using Ganss.Excel;
using Read.XLSX.Application.Helpers;
using Read.XLSX.Domain.Contracts.Application;
using Read.XLSX.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Read.XLSX.Application.Applications
{
    public class GetValoresApplication : IGetValoresApplication
    {
        private readonly string _diretorio = @"D:\Projeto_C#\Read.XLSX\src\Documentos\Testes\Classes.xlsx";
        public GetValoresApplication()
        {}
        
        public async Task<object> GetValoresXlsx()
        {
            var usuarios = GetUsuariosDaTabela();
            var pagamentos = GetPagamentosDaTablela();

            var GridA = Utils.GetPagamentos();
            var GridB = Utils.GetPagamentos();
            var GridC = Utils.GetPagamentos();


            GridA = pagamentos.Where(e => e.Tipo == "Luz").ToList();
            GridB = pagamentos.Where(e => e.Tipo == "Água").ToList();
            GridC = pagamentos.Where(e => e.Tipo == "Internet").ToList();

            return await Task.FromResult(new {GridA, GridB, GridC});
        }

        private IEnumerable<Usuario> GetUsuariosDaTabela()
        {
           return new ExcelMapper(_diretorio).Fetch<Usuario>("Planilha1");
        }

        private List<Pagamento> GetPagamentosDaTablela()
        {
            var exelMapping = new ExcelMapper(_diretorio);

            exelMapping.AddMapping<Pagamento>("Pagamento ID", e => e.Id);
            var retorno = exelMapping.Fetch<Pagamento>("Planilha2");
            return retorno.ToList();
        }
    }
}
