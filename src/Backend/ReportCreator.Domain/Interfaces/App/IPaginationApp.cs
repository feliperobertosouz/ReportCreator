using ReportCreator.Domain.DTOs.Requests.Base;
using ReportCreator.Domain.DTOs.Responses.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Domain.Interfaces.Apps
{
    public interface IPaginationApp
    {
        public PaginationResponseDTO<T> Paginate<T>(RequestPaginationBaseDTO request);
    }
}
