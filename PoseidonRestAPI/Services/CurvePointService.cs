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
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _curvePointRepository;
        private readonly IMapper _mapper;

        public CurvePointService(ICurvePointRepository curvePointRepository,
                                 IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            
            _curvePointRepository = curvePointRepository ??
                throw new ArgumentNullException(nameof(_curvePointRepository));
        }

        public CurvePointDTO[] FindAll()
        {
            return _curvePointRepository.GetAll()
                               .Where(x => x.CurveId > 0)
                               .Select(x => _mapper.Map<CurvePointDTO>(x)).ToArray();
        }

        public CurvePointDTO FindById(int Id)
        {
            var _curvepoint = _curvePointRepository.FindById(Id);
            return _mapper.Map<CurvePointDTO>(_curvepoint);
        }


        public CurvePointDTO Add(EditCurvePointDTO editCurvePointDTO)
        {
            if (editCurvePointDTO == null)
            {
                throw new ArgumentException();
            }

            var currentCurvePoint = _mapper.Map<CurvePoint>(editCurvePointDTO);
            try
            {
                _curvePointRepository.Insert(currentCurvePoint);
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<CurvePointDTO>(currentCurvePoint);
        }


        public void Update(int Id, EditCurvePointDTO editCurvePointDTO)
        {
            var updateCurvePoint = _curvePointRepository.FindById(Id);
            if (updateCurvePoint != null && editCurvePointDTO != null)
            {
                //_bidListRepository.Update(Id, updateBidList);
            }
        }

        public void Delete(int Id)
        {
            _curvePointRepository.Delete(Id);
        }

    }
}
