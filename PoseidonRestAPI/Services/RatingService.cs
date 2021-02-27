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
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository,
                              IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));

            _ratingRepository = ratingRepository ??
                throw new ArgumentNullException(nameof(_ratingRepository));
        }

        // find
        public RatingDTO[] FindAll()
        {
            return _ratingRepository.GetAll()
                               .Where(x => x.Id > 0)
                               .Select(x => _mapper.Map<RatingDTO>(x)).ToArray();
        }

        public RatingDTO FindById(int Id)
        {
            var _bidlist = _ratingRepository.FindById(Id);
            return _mapper.Map<RatingDTO>(_bidlist);
        }

        // add 
        public RatingDTO Add(EditRatingDTO editRatingDTO)
        {
            if (editRatingDTO == null)
            {
                throw new ArgumentException();
            }

            var currentRating = _mapper.Map<Rating>(editRatingDTO);
            try
            {
                _ratingRepository.Insert(currentRating);
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<RatingDTO>(currentRating);
        }

        // edit
        public void Update(int Id, EditRatingDTO editRatingDTO)
        {
            var updateRating = _ratingRepository.FindById(Id);
            if (updateRating != null && editRatingDTO != null)
            {
                _ratingRepository.Update(Id, _mapper.Map(editRatingDTO, updateRating));
            }
        }

        public void Delete(int Id)
        {
            _ratingRepository.Delete(Id);
        }
    }
}
