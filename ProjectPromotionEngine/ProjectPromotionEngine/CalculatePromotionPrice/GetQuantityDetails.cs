using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotionEngine.CalculatePromotionPrice
{
    public class GetQuantityDetails
    {
        public string AQty { get; set; }

        public string BQty { get; set; }

        public string CQty { get; set; }

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
