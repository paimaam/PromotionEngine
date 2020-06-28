using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotionEngine.CalculatePromotionPrice
{
    public class GetQuantityDetails
    {
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter a valid number")]
        public string AQty { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter a valid number")]
        public string BQty { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter a valid number")]
        public string CQty { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter a valid number")]
        public string DQty { get; set; }

        public GetQuantityDetails (string aQty, string bQty, string cQty, string dQty)
        {
            AQty = aQty;
            BQty = bQty;
            CQty = cQty;
            DQty = dQty;
        }


    }
}
