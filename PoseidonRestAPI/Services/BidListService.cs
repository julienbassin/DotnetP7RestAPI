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

        public BidListService(IBidListRepository bidListRepository,
                              IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));

            _bidListRepository = bidListRepository ??
                throw new ArgumentNullException(nameof(_bidListRepository));
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
        public void Update(int Id, EditBidListDTO editBidListDTO)
        {
            var updateBidList = _bidListRepository.FindById(Id);
            if(updateBidList != null && editBidListDTO != null)
            {                
                _bidListRepository.Update(Id, updateBidList);
            }
        }

        public void Delete(int Id)
        {
            _bidListRepository.Delete(Id);
        }
    }
}
