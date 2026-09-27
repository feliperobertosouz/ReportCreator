using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Domain.DTOs
{
    public class ResponseErrorDTO
    {
        public List<string> Errors { get; private set; } = new();

        public ResponseErrorDTO(List<string> errors)
        {
            Errors = errors;
        }

        public ResponseErrorDTO(string error)
        {
            Errors = [error];
        }
    }
}
