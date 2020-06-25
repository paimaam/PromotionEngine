using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotionEngine.ImplentationAccordingToSKU
{
    interface IGetValueOfEachSKU
    {
        public int TotalPriceOfA(int quantityOfA);

        public int TotalPriceOfB(int quantityOfA);

        public int TotalPriceOfCAndD(int quantityOfC, int quantityOfD);
    }
}
