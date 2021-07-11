using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    /// <summary>
    /// Дитали товара
    /// </summary>
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float PurchasePrice { get; set; }
    }
}