using FluentValidation;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.ModelValidator
{
    public class TradeValidator : ValidatorBase<EditTradeDTO>
    {
        public TradeValidator()
        {
            RuleFor(tr => tr.Account).NotEmpty()
                                     .MaximumLength(10);
            RuleFor(tr => tr.BuyQuantity).NotEmpty();
            RuleFor(tr => tr.Type).NotEmpty()
                                  .MaximumLength(10);
        }
    }
}
