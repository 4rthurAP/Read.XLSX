using Domain.Models.Base;

namespace Domain.Models
{
    public class Pagamento : BaseEntity
    {
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
