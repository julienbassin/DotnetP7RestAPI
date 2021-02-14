using AutoMapper;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Services
{
    public class TradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public TradeService(ITradeRepository tradeRepository,
                              IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));

            _tradeRepository = tradeRepository ??
                throw new ArgumentNullException(nameof(_tradeRepository));
        }

        // find
        public TradeDTO[] FindAll()
        {
            return _tradeRepository.GetAll()
                               .Where(x => x.TradeId > 0)
                               .Select(x => _mapper.Map<TradeDTO>(x)).ToArray();
        }

        public TradeDTO FindById(int Id)
        {
            var _trade = _tradeRepository.FindById(Id);
            return _mapper.Map<TradeDTO>(_trade);
        }

        // add 
        public TradeDTO Add(EditTradeDTO editTradeDTO)
        {
            if (editTradeDTO == null)
            {
                throw new ArgumentException();
            }

            var currentTrade = _mapper.Map<Trade>(editTradeDTO);
            try
            {
                _tradeRepository.Insert(currentTrade);
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<TradeDTO>(currentTrade);
        }

        // edit
        public void Update(int Id, EditTradeDTO editTradeDTO)
        {
            var updateTrade = _tradeRepository.FindById(Id);
            if (updateTrade != null && editTradeDTO != null)
            {
                //_bidListRepository.Update(Id, updateBidList);
            }
        }

        public void Delete(int Id)
        {
            _tradeRepository.Delete(Id);
        }
    }
}
