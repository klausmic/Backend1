using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Data
{
    [Table("Market")]
    public class Market
    {
        public int MarketId { get; set; }
        public string MarketCode { get; set; }
        public string MarketName { get; set; }
        public bool isActive { get; set; }

    }
}
