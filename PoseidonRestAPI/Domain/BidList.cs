using System.ComponentModel.DataAnnotations;
using System;

namespace PoseidonRestAPI.Domain
{
    public class BidList
    {
        [Key]
        public int BidListId { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }
        public double BidQuantity { get; set; }
        public double AskQuantity { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public string BenchMark { get; set; }
        public DateTime? BidListDate { get; set; } = DateTime.Now;
        public string Commentary { get; set; }
        public string Security { get; set; }
        public string Status { get; set; }
        public string Trader { get; set; }
        public string Book { get; set; }
        public string CreationName { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public string RevisionName { get; set; }

        [Timestamp]
        public DateTime? RevisionDate { get; set; } = DateTime.Now;
        public string DealName { get; set; }
        public string SourceListId { get; set; }
        public string Side { get; set; }
    }
}