using ReportCreator.Domain.DTOs.Requests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Domain.Interfaces.App
{
    public interface IReportApp
    {
        public void RegisterReport(RequestReportBaseDTO reportRequest);
    }
}
