using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator.Domain.DTOs.Responses.Base
{
    public class ReportDTO
    {
        public ReportDTO(string name, string description, string generatedBy)
        {
            Name = name;
            Description = description;
            GeneratedBy = generatedBy;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset GenerationDate { get; set; } = DateTimeOffset.UtcNow;
        public string GeneratedBy { get; set; } = string.Empty;
    }
}
