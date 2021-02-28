using FluentValidation;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.ModelValidator
{
    public class UserValidator : ValidatorBase<EditUserDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty()
                                    .MaximumLength(10);
            RuleFor(u => u.FullName).NotEmpty()
                                    .MaximumLength(30);
            RuleFor(u => u.Password).NotEmpty()
                                    .Must(Password => IsPasswordStrong(Password));
            RuleFor(u => u.Role).NotEmpty()
                                .MaximumLength(10);
        }


        private bool IsPasswordStrong(string password)
        {
            if (String.IsNullOrEmpty(password))
                return false;

            if (password.Length < 6)
                return false;

            return Regex.IsMatch(password, @"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
        }
    }
}
