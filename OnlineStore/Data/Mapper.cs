using OnlineStore.ViewModels;
using OnlineStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Data
{
    public class Mapper
    {
        // rewrite this shit
        public static ProductViewModel Map(Product data)
        {
            ProductViewModel resoult = new ProductViewModel()
            {
                Name = data.Name,
                ShortDescription = data.ShortDescription,
                Price = data.Price,
                MainImage = data.MainImage                
            };

            return resoult;
        }

        public static List<ProductViewModel> Map(List<Product> data)
        {
            var resoult = new List<ProductViewModel>();

            foreach(var e in data)
            {
                resoult.Add(Mapper.Map(e));
            }

            return resoult;
        }
    }
}