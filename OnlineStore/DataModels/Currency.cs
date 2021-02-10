using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    /// <summary>
    /// Валюта (денежная валюта)
    /// </summary>
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string Name { get; set; }

        [Required]
        [MaxLength(8)]
        public string ShortName { get; set; } // $, £, € руб., сом

        /// <summary>
        /// Курс валюты к доллару США. Нужно цену товара умножить на курс и получится цена в новой валюте.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public double ExchangeRate { get; set; }
    }
}