using FluentValidation;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.ModelValidator
{
    public class CurvePointValidator : ValidatorBase<EditCurvePointDTO>
    {
        public CurvePointValidator()
        {
            RuleFor(cp => cp.Id).NotNull();

            RuleFor(cp => cp.Term).NotEmpty();

            RuleFor(cp => cp.Value).NotEmpty();
        }
    }
}
