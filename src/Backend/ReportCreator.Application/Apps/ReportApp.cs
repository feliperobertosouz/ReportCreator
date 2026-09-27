using ReportCreator.Application.Validators;
using ReportCreator.Domain.DTOs.Requests.Base;
using ReportCreator.Domain.Interfaces.App;
using ReportCreator.Exception.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Application.Apps
{
    public class ReportApp : IReportApp
    {
        public void RegisterReport(RequestReportBaseDTO reportRequest)
        {
            var validator = new ReportRequestValidator();
            var resultValidation = validator.Validate(reportRequest);

            if(!resultValidation.IsValid)
            {
                var errorMessages = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
