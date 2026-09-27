using System;

namespace ReportCreator.Domain.DTOs.Requests.Base
{
    /// <summary>
    /// Enum que representa as opções de agrupamento/amostragem de tempo para relatórios.
    /// </summary>
    public enum TimeAggregation
    {
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    /// <summary>
    /// Classe base para requisições de criação de relatório.
    /// Contém propriedades comuns como intervalo de tempo e agrupamento.
    /// </summary>
    public class RequestReportBaseDTO
    {
        /// <summary>
        /// Indica se o intervalo de tempo será usado. Quando true, Start e End devem ser informados.
        /// </summary>
        public bool UseTimeRange { get; set; } = true;

        /// <summary>
        /// Início do intervalo de tempo (opcional se UseTimeRange for false).
        /// Use DateTimeOffset para preservar informações de fuso horário.
        /// </summary>
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// Fim do intervalo de tempo (opcional se UseTimeRange for false).
        /// </summary>
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// Agrupamento/amostragem desejada para o relatório.
        /// </summary>
        public TimeAggregation Aggregation { get; set; } = TimeAggregation.Daily;

        }
}
