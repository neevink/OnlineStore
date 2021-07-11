using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        // Изображение пока не используется
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// Продукты, принадлежащие этой категории
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}