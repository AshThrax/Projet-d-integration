﻿using ApplicationTheather.DTO;
using FluentValidation;

namespace WebApi.Validator
{
    public class UpdtSalleValidator : AbstractValidator<UpdateSalleDeTheatreDto>
    {
        public UpdtSalleValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
