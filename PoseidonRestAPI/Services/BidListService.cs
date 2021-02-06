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
    public class BidListService : IBidListService
    {
        private readonly IBidListRepository _bidListRepository;
        private readonly IMapper _mapper;

        public BidListService(IBidListRepository bidListRepository, IMapper mapper)
        {
            _bidListRepository = bidListRepository;
            _mapper = mapper;
        }

        // find
        public BidListDTO[] FindAll()
        {
            return _bidListRepository.GetAll()
                               .Where(x => x.BidListId > 0)
                               .Select(x => _mapper.Map<BidListDTO>(x)).ToArray();
        }

        public BidListDTO FindById(int Id)
        {
            var _bidlist = _bidListRepository.FindById(Id);
            return _mapper.Map<BidListDTO>(_bidlist);
        }

        // add 
        public BidListDTO Add(EditBidListDTO editBidListDTO)
        {
            if (editBidListDTO == null)
            {
                throw new ArgumentException();
            }

            var currentBid = _mapper.Map<BidList>(editBidListDTO);
            try
            {                
                _bidListRepository.Insert(currentBid);
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<BidListDTO>(currentBid);
        }

        // edit
        public void Update(EditBidListDTO editBidListDTO)
        {

            if(editBidListDTO != null)
            {
                var updateBidList = _mapper.Map<BidList>(editBidListDTO);
                _bidListRepository.Update(updateBidList);
            }
        }

        public void Delete(int Id)
        {
            _bidListRepository.Delete(Id);
        }
    }
}
