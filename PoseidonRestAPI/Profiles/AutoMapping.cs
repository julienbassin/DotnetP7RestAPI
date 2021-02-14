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
            // Bidlist
            CreateMap<BidListDTO, BidList>();
            CreateMap<BidList, BidListDTO>();
            CreateMap<EditBidListDTO, BidList>();

            // CurvePoint
            CreateMap<CurvePointDTO, CurvePoint>();
            CreateMap<CurvePoint, CurvePointDTO>();
            CreateMap<EditCurvePointDTO, CurvePoint>();

            // Rating
            CreateMap<RatingDTO, Rating>();
            CreateMap<Rating, RatingDTO>();
            CreateMap<EditRatingDTO, Rating>();

            // Rule
            CreateMap<RuleDTO, Rule>();
            CreateMap<Rule, RuleDTO>();
            CreateMap<EditRuleDTO, Rule>();

            // Trade
            CreateMap<TradeDTO, Trade>();
            CreateMap<Trade, TradeDTO>();
            CreateMap<EditTradeDTO, Trade>();

            // User
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<EditUserDTO, User>();
        }
    }
}
