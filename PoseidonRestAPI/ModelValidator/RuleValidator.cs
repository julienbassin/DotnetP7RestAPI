using FluentValidation;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.ModelValidator
{
    public class RuleValidator : ValidatorBase<EditRuleDTO>
    {
        public RuleValidator()
        {
            RuleFor(rl => rl.Name).NotEmpty()
                                  .MaximumLength(10);
            RuleFor(rl => rl.Description).NotEmpty()
                                         .MaximumLength(10);
            RuleFor(rl => rl.Json).NotEmpty()
                                  .MaximumLength(10);
        }
    }
}
