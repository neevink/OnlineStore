using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата и время заказа
        /// </summary>
        [Required]
        public DateTime Time { get; set; }

        /// <summary>
        /// Заказчик/покупатель
        /// </summary>
        [Required]
        public Account Customer { get; set; }

        public List<OrderDetail> Details { get; set; }
    }
}