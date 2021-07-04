using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lo_fi_api.Model
{
    public class CreditCard
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 12)]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CVC { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
    }
}
