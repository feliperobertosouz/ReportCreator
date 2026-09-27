using System.Collections.Generic;
using ReportCreator.Domain.DTOs.Requests;

namespace ReportCreator.Domain.Interfaces.Repository
{
    /// <summary>
    /// Repositório genérico simples usado pela paginação.
    /// Implementações concretas devem fornecer lógica de consulta e contagem.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade/DTO retornada.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Retorna os itens paginados aplicando skip/take e opcional ordenação.
        /// </summary>
        IEnumerable<T> GetPaged(int skip, int take, string? sortBy, SortDirection sortDirection);

        /// <summary>
        /// Retorna a contagem total de itens sem paginação.
        /// </summary>
        long Count();
    }
}
