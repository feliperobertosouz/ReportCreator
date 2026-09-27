using FluentValidation;
using ReportCreator.Domain.DTOs.Requests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Application.Validators
{
    public class ReportRequestValidator : AbstractValidator<RequestReportBaseDTO>
    {
        public ReportRequestValidator()
        {
            RuleFor(x => x.Start)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.End)
                .NotEmpty().WithMessage("End date is required.");

            RuleFor(x => x.End)
                .GreaterThan(x => x.Start).WithMessage("End date must be greater than start date.");

            RuleFor(x => x.Start)
                .LessThan(x => x.End).WithMessage("Start date must be less than end date.");


        }
    }
}
