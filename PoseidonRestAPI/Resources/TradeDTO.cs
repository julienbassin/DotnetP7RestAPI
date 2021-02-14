using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Resources
{
    public class TradeDTO
    {
        public int TradeId { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }
        public double BuyQuantity { get; set; }
    }

    public class EditTradeDTO
    {
        public string Account { get; set; }
        public string Type { get; set; }
        public double BuyQuantity { get; set; }
    }
}
