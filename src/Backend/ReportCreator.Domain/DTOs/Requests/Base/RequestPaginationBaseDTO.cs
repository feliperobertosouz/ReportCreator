using System;

namespace ReportCreator.Domain.DTOs.Requests.Base
{
    /// <summary>
    /// Direção de ordenação para paginação.
    /// </summary>
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    /// <summary>
    /// DTO base para requisições paginadas em controllers.
    /// Contém página, tamanho, ordenação e utilitários básicos.
    /// </summary>
    public class RequestPaginationBaseDTO
    {
        /// <summary>
        /// Número da página (1-based). Default = 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Tamanho da página. Default = 20.
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Tamanho máximo permitido para PageSize. Pode ser ajustado conforme necessidade.
        /// </summary>
        public const int MaxPageSize = 100;

        /// <summary>
        /// Campo pelo qual a lista será ordenada (opcional).
        /// </summary>
        public string? SortBy { get; set; }

        /// <summary>
        /// Direção da ordenação (Ascending ou Descending). Default = Ascending.
        /// </summary>
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;

        /// <summary>
        /// Retorna o offset (skip) calculado a partir de PageNumber e PageSize.
        /// </summary>
        public int Skip => (Math.Max(1, PageNumber) - 1) * Math.Max(1, PageSize);

        /// <summary>
        /// Valida valores básicos do DTO. Lança ArgumentException em caso de parâmetros inválidos.
        /// </summary>
        public virtual void Validate()
        {
            if (PageNumber < 1)
                throw new ArgumentException("PageNumber must be greater than or equal to 1.");

            if (PageSize < 1)
                throw new ArgumentException("PageSize must be greater than or equal to 1.");

            if (PageSize > MaxPageSize)
                throw new ArgumentException($"PageSize cannot exceed {MaxPageSize}.");
        }
    }
}
