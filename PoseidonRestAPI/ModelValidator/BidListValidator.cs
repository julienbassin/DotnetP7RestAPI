using FluentValidation;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.ModelValidator
{
    public class BidListValidator : ValidatorBase<EditBidListDTO>
    {
        public BidListValidator()
        {
            RuleFor(bl => bl.Account).NotEmpty()
                                     .MaximumLength(10);

            RuleFor(bl => bl.BidQuantity).NotEmpty();

            RuleFor(bl => bl.Type).NotEmpty()
                                  .MaximumLength(10);
        }
    }
}
