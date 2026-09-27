using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCreator.Domain.DTOs.Responses.Base
{
    /// <summary>
    /// DTO genérico base para respostas paginadas.
    /// Contém os itens da página e metadados de paginação.
    /// </summary>
    /// <typeparam name="T">Tipo dos itens paginados.</typeparam>
    public class PaginationResponseDTO<T>
    {
        /// <summary>
        /// Itens retornados nesta página.
        /// </summary>
        public IReadOnlyList<T> Items { get; init; }

        /// <summary>
        /// Número da página (1-based).
        /// </summary>
        public int PageNumber { get; init; }

        /// <summary>
        /// Tamanho da página.
        /// </summary>
        public int PageSize { get; init; }

        /// <summary>
        /// Quantidade total de itens disponíveis (sem paginação).
        /// </summary>
        public long TotalItems { get; init; }

        /// <summary>
        /// Quantidade total de páginas calculada a partir de TotalItems e PageSize.
        /// </summary>
        public int TotalPages { get; init; }

        /// <summary>
        /// Indica se existe página anterior.
        /// </summary>
        public bool HasPrevious => PageNumber > 1;

        /// <summary>
        /// Indica se existe próxima página.
        /// </summary>
        public bool HasNext => PageNumber < TotalPages;

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="items">Itens da página (pode ser null, será convertido para lista vazia).</param>
        /// <param name="totalItems">Total de itens sem paginação.</param>
        /// <param name="pageNumber">Número da página (1-based).</param>
        /// <param name="pageSize">Tamanho da página.</param>
        public PaginationResponseDTO(IEnumerable<T>? items, long totalItems, int pageNumber, int pageSize)
        {
            Items = (items ?? Enumerable.Empty<T>()).ToList();
            TotalItems = Math.Max(0, totalItems);
            PageNumber = Math.Max(1, pageNumber);
            PageSize = Math.Max(1, pageSize);
            TotalPages = PageSize == 0 ? 0 : (int)Math.Ceiling(TotalItems / (double)PageSize);
        }

        /// <summary>
        /// Cria uma resposta paginada a partir de uma lista já paginada e o total de itens.
        /// </summary>
        public static PaginationResponseDTO<T> From(IEnumerable<T>? items, long totalItems, int pageNumber, int pageSize)
            => new PaginationResponseDTO<T>(items, totalItems, pageNumber, pageSize);
    }
}
