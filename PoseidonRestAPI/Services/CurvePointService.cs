﻿using AutoMapper;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.ModelValidator;
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

        public ValidationResult ValidateResource(EditCurvePointDTO editCurvePointDTO)
        {
            var result = new ValidationResult();
            if (editCurvePointDTO != null)
            {
                var validator = new CurvePointValidator();
                var vr = validator.Validate(editCurvePointDTO);
                if (vr.IsValid)
                {
                    result.IsValid = true;
                    return result;
                }

                if (vr.Errors.Any())
                {
                    foreach (var error in vr.Errors)
                    {
                        result.ErrorMessages.Add(error.PropertyName, error.ErrorMessage);
                    }
                }
            }

            return result;
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
            var CurvePoint = _curvePointRepository.FindById(Id);
            if (CurvePoint != null && editCurvePointDTO != null)
            {
                _curvePointRepository.Update(Id, _mapper.Map(editCurvePointDTO, CurvePoint));
            }
        }

        public void Delete(int Id)
        {
            _curvePointRepository.Delete(Id);
        }

    }
}
