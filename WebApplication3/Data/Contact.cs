using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace WebApplication3.Data
{
    [Table("Contact")]
    public class Contact
    {
        public int ContactId { get; set; }
        public int MarketId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CreatedTimestamp { get; set; }
        public string Note { get; set; }
        public bool IsClosed { get; set; }

    }
    
}