using ReportCreator.Domain.DTOs.Requests.Base;
using ReportCreator.Domain.DTOs.Responses.Base;
using ReportCreator.Domain.Interfaces.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Application.Apps
{
    public class ReportPaginationApp : PaginationAppBase, IPaginationApp
    {
        public static readonly List<ReportDTO> reportsTest = new List<ReportDTO>
        {
            new ReportDTO("Report 1", "Description for Report 1", "User A"),
            new ReportDTO("Report 2", "Description for Report 2", "User B"),
            new ReportDTO("Report 3", "Description for Report 3", "User C"),
            new ReportDTO("Report 4", "Description for Report 4", "User D"),
            new ReportDTO("Report 5", "Description for Report 5", "User E"),
            new ReportDTO("Report 6", "Description for Report 6", "User F"),
            new ReportDTO("Report 7", "Description for Report 7", "User G"),
            new ReportDTO("Report 8", "Description for Report 8", "User H"),
            new ReportDTO("Report 9", "Description for Report 9", "User I"),
            new ReportDTO("Report 10", "Description for Report 10", "User J"),
            new ReportDTO("Report 11", "Description for Report 11", "User AA"),
            new ReportDTO("Report 12", "Description for Report 12", "User AB"),
            new ReportDTO("Report 13", "Description for Report 13", "User AC"),
            new ReportDTO("Report 14", "Description for Report 14", "User AD"),
            new ReportDTO("Report 15", "Description for Report 15", "User AE"),
            new ReportDTO("Report 16", "Description for Report 16", "User AF"),
            new ReportDTO("Report 17", "Description for Report 17", "User AG"),
            new ReportDTO("Report 18", "Description for Report 18", "User AH"),
            new ReportDTO("Report 19", "Description for Report 19", "User AI"),
            new ReportDTO("Report 20", "Description for Report 20", "User AJ")
        };

        
        public override PaginationResponseDTO<T> Paginate<T>(RequestPaginationBaseDTO request)
        {
            return base.Paginate<T>(request);
        }

        protected override IEnumerable<T> GetAllItems<T>(RequestPaginationBaseDTO request)
        {
            return reportsTest.Cast<T>();
        }
    }
}
