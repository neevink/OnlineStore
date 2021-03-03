using OnlineStore.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

using Image = System.Drawing.Image;

namespace OnlineStore.Data
{
    public class StoreContextInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            Role admin = new Role() { Id = RoleEnum.Admin, Name = "Администратор" };
            Role customer = new Role() { Id = RoleEnum.Customer, Name = "Покупатель" };

            db.Roles.Add(admin);
            db.Roles.Add(customer);

            Color white = new Color() { Name = "Белый" };
            Color oak = new Color() { Name = "Дуб" };
            Color black = new Color() { Name = "Чёрный" };

            db.Colors.Add(white);
            db.Colors.Add(oak);
            db.Colors.Add(black);

            Product table = new Product()
            {
                SKU = "392.271.68",
                Name = "Стол MELLTORP",
                ShortDescription = "Стол белый глянцевый, 75x75 см",
                Description = "Этот стол подойдет любому — от одинокого любителя минимализма до большой шумной семьи с детьми, которые все проверяют на прочность. Его можно поставить на кухню или в столовую, а его лаконичный дизайн будет гармонично сочетаться с самыми разными стилями.",
                Color = white,
                Width = 75,
                Length = 75,
                Hight = 74,
                StockQuantity = 10,
                Price = 34,
                MainImage = GetImageBytesFromPath(@"E:\VisualStudioProjects\OnlineStore\OnlineStore\Content\melltorp-stol.jpg")
            };
            Product chair = new Product()
            {
                SKU = "504.882.01",
                Name = "Стул EGGELSTAD",
                ShortDescription = "Стул деревянный",
                Description = "Деревянный стул лаконичного дизайна из прочного массива березы прослужит вам долгие годы. Подойдет к большинству столов, а для оптимального комфорта на сиденье можно положить подушку.",
                Color = oak,
                Width = 37,
                Length = 48,
                Hight = 87,
                StockQuantity = 4,
                Price = 25,
                MainImage = GetImageBytesFromPath(@"E:\VisualStudioProjects\OnlineStore\OnlineStore\Content\eggelstad-chair.jpg")
            };
            Product wardrobe = new Product()
            {
                SKU = "804.537.66",
                Name = "Гардероб РАККЕСТАД",
                ShortDescription = "Гардероб 3-дверный, черный 117x176 см",
                Description = "Просто и практично — идеально, когда вам достаточно гардероба с базовыми функциями. А если места для хранения окажется мало, всегда можно докупить еще один гардероб серии РАККЕСТАД!",
                Color = black,
                Width = 117,
                Length = 55,
                Hight = 176,
                StockQuantity = 2,
                Price = 109,
                MainImage = GetImageBytesFromPath(@"E:\VisualStudioProjects\OnlineStore\OnlineStore\Content\rakkestad-wardrobe.jpg")
            };

            db.Products.Add(table);
            db.Products.Add(chair);
            db.Products.Add(wardrobe);

            db.SaveChanges();
        }

        protected static byte[] GetImageBytesFromPath(string path)
        {
            Image img = Image.FromFile(path);
            byte[] tableBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                tableBytes = ms.ToArray();
            }

            return tableBytes;
        }
    }
}