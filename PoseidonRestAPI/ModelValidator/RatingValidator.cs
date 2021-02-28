using FluentValidation;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.ModelValidator
{
    public class RatingValidator : ValidatorBase<EditRatingDTO>
    {
        public RatingValidator()
        {
            RuleFor(rt => rt.MoodysRating).NotNull()
                                          .MaximumLength(10);
            RuleFor(rt => rt.SandPRating).NotNull()
                                         .MaximumLength(10);
            RuleFor(rt => rt.FitchRating).NotNull()
                                         .MaximumLength(10);
            RuleFor(rt => rt.OrderNumber).NotNull();
        }
    }
}
