using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Resources
{
    public class BidListDTO
    {
        public int BidListId { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }
        public double BidQuantity { get; set; }
    }

    public class EditBidListDTO
    {
        public string Account { get; set; }
        public string Type { get; set; }
        public double BidQuantity { get; set; }
    }
}
