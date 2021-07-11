using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    // Пока не используется, да и тип мебели лучше сделать через enum
    public class FurnitureType
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// Картинка типа мебели (картинка главной категории)
        /// </summary>
        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }
    }
}