using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}