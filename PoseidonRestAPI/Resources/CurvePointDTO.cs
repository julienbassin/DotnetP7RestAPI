using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Resources
{
    public class CurvePointDTO
    {
        public int CurveId { get; set; }
        public int Id { get; set; }
        public double Term { get; set; }
        public double Value { get; set; }

    }

    public class EditCurvePointDTO
    {
        public int Id { get; set; }
        public double Term { get; set; }
        public double Value { get; set; }
    }
}
