using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SelfCheckoutMachine.Models
{
    public class Cash
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CashTypeId { get; set; }
        public int Amount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
