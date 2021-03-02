using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public byte[] MainImage { get; set; }
        public double Price { get; set; }
    }
}