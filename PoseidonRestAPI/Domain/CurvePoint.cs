using System.ComponentModel.DataAnnotations;
using System;

namespace PoseidonRestAPI.Domain
{
    public class CurvePoint
    {
        [Key]
        public int CurveId { get; set; }
        public int Id { get; set; }        
        public DateTime? AsOfDate { get; set; } = DateTime.Now;
        public double Term { get; set; }
        public double Value { get; set; }        
        public DateTime? CreationTime { get; set; } = DateTime.Now;
    }
}