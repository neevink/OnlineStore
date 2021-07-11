using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(32)]
        public string Name { get; set; }

        //[Required]
        //[MaxLength(32)]
        public string ShortDescription { get; set; }

        //[Required]
        //[MaxLength(128)]
        public string Description { get; set; }

        /// <summary>
        /// Артикул товара
        /// </summary>
        //[Required]
        //[MaxLength(16)]
        public string SKU { get; set; }

        public int? ColorId { get; set; }

        //[Required]
        public Color Color { get; set; }

        /// <summary>
        /// Ширина
        /// </summary>
        //[Required]
        //[Range(0, int.MaxValue)]
        public int Width { get; set; }

        /// <summary>
        /// Длина (глубина)
        /// </summary>
        //[Required]
        //[Range(0, int.MaxValue)]
        public int Length { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        //[Required]
        //[Range(0, int.MaxValue)]
        public int Hight { get; set; }
        
        //[Column(TypeName = "image")]
        public byte[] MainImage { get; set; }
        
        public List<ProductImage> Images { get; set; }

        /// <summary>
        /// Цена в долларах США
        /// </summary>
        //[Required]
        //[Range(0, double.MaxValue)]
        public double Price { get; set; }

        /// <summary>
        /// Количсество единиц на складе
        /// </summary>
        //[Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}