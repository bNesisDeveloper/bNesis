using System;
using System.ComponentModel.DataAnnotations;

namespace bNesis.Examples.DiscountCalculationApp.DAL.Models
{
    /// <summary>
    /// Api method response
    /// </summary>
    public class ApiResponse
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Provider name
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Response data
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        public DateTime Created { get; set; }
    }
}