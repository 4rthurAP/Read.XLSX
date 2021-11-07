using Read.XLSX.Domain.Contracts.Application;
using System;
using System.Threading.Tasks;

namespace Read.XLSX.Application.Applications
{
    public class GetValoresApplication : IGetValoresApplication
    {
        public Task GetValoresXlsx()
        {
            var fileName = @"C:\Temp\Names.xlsx"; // your Excel file
            var people = new ExcelMapper(fileName).Fetch<Person>();
            throw new NotImplementedException();
        }
    }
}
