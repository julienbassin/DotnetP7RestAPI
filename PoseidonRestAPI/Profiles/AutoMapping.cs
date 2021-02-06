using AutoMapper;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BidListDTO, BidList>();
            CreateMap<BidList, BidListDTO>();
            CreateMap<EditBidListDTO, BidList>();
        }
    }
}
