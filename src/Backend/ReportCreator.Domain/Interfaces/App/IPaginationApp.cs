using ReportCreator.Domain.DTOs.Requests;
using ReportCreator.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Domain.Interfaces.Apps
{
    public interface IPaginationApp
    {
        public PaginationResponseDTO<T> Paginate<T>(RequestPaginationBase request);
    }
}
