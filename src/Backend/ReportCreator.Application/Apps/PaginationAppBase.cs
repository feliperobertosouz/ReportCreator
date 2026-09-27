using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ReportCreator.Domain.DTOs.Requests.Base;
using ReportCreator.Domain.DTOs.Responses.Base;
using ReportCreator.Domain.Interfaces;
using ReportCreator.Domain.Interfaces.Apps;

namespace ReportCreator.Application.Apps
{
    /// <summary>
    /// Implementação base reutilizável para paginação. Fornece métodos protegidos
    /// que podem ser utilizados por aplicações concretas para paginar uma coleção
    /// já obtida ou para gerar dados fictícios em ambiente de teste.
    /// </summary>
    public class PaginationAppBase : IPaginationApp
    {
        // Quantidade total padrão de itens fictícios
        protected const int DefaultTotalItems = 50;

        /// <summary>
        /// Método principal da interface. Pode ser sobrescrito por implementações
        /// concretas que busquem dados de uma fonte real. A implementação padrão
        /// obtém uma lista fictícia e aplica paginação.
        /// </summary>
        public virtual PaginationResponseDTO<T> Paginate<T>(RequestPaginationBaseDTO request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            request.Validate();

            var allItems = GetAllItems<T>(request);

            return PaginateFromList(allItems, request);
        }

        /// <summary>
        /// Método protegido que aplica lógica de paginação (skip/take) sobre uma coleção.
        /// Retorna um PaginationResponseDTO com os metadados calculados.
        /// </summary>
        protected PaginationResponseDTO<T> PaginateFromList<T>(IEnumerable<T> allItems, RequestPaginationBaseDTO request)
        {
            var itemsList = (allItems ?? Enumerable.Empty<T>()).ToList();
            var total = itemsList.LongCount();

            var skip = Math.Max(0, (request.PageNumber - 1) * request.PageSize);
            var take = Math.Max(0, request.PageSize);

            var pageItems = itemsList.Skip(skip).Take(take).ToList();

            return PaginationResponseDTO<T>.From(pageItems, total, request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// Método protegido que obtém todos os itens a serem paginados. A implementação
        /// padrão gera dados fictícios; classes filhas podem sobrescrever para buscar
        /// de repositórios, bancos de dados ou APIs.
        /// </summary>
        protected virtual IEnumerable<T> GetAllItems<T>(RequestPaginationBaseDTO request)
        {
            return GenerateFakeItems<T>(DefaultTotalItems);
        }

        /// <summary>
        /// Gera uma lista de itens fictícios para testes/desenvolvimento.
        /// </summary>
        protected static List<T> GenerateFakeItems<T>(int total)
        {
            var list = new List<T>();
            var tType = typeof(T);

            for (int i = 1; i <= total; i++)
            {
                object? itemObj = null;

                if (tType == typeof(string))
                {
                    itemObj = $"Item {i}";
                }
                else if (tType == typeof(int))
                {
                    itemObj = i;
                }
                else if (tType == typeof(long))
                {
                    itemObj = (long)i;
                }
                else if (tType == typeof(double))
                {
                    itemObj = (double)i;
                }
                else
                {
                    // tenta criar uma instância e popular propriedades simples
                    try
                    {
                        var instance = Activator.CreateInstance<T>();
                        if (instance != null)
                        {
                            PopulateSimpleProperties(instance, i);
                            itemObj = instance;
                        }
                    }
                    catch
                    {
                        // se não for possível instanciar, continue com default
                        itemObj = default(T);
                    }
                }

                if (itemObj == null && default(T) != null)
                    itemObj = default(T);

                list.Add((T?)itemObj!);
            }

            return list;
        }

        /// <summary>
        /// Popula propriedades públicas simples de uma instância para gerar dados plausíveis.
        /// </summary>
        private static void PopulateSimpleProperties<T>(T instance, int index)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && p.GetIndexParameters().Length == 0);

            foreach (var prop in props)
            {
                var pt = prop.PropertyType;
                try
                {
                    if (pt == typeof(string))
                        prop.SetValue(instance, $"{prop.Name} {index}");
                    else if (pt == typeof(int))
                        prop.SetValue(instance, index);
                    else if (pt == typeof(long))
                        prop.SetValue(instance, (long)index);
                    else if (pt == typeof(double))
                        prop.SetValue(instance, (double)index);
                    else if (pt == typeof(decimal))
                        prop.SetValue(instance, (decimal)index);
                    else if (pt == typeof(bool))
                        prop.SetValue(instance, index % 2 == 0);
                    else if (pt == typeof(DateTime))
                        prop.SetValue(instance, DateTime.UtcNow.AddDays(-index));
                    else if (pt.IsEnum)
                    {
                        var values = Enum.GetValues(pt);
                        if (values.Length > 0)
                            prop.SetValue(instance, values.GetValue(0));
                    }
                }
                catch
                {
                    // ignora erros de conversão/atribuição
                }
            }
        }
    }
}
