using Read.XLSX.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.XLSX.Domain.Models
{
    public class Pagamento : BaseEntity
    {
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
