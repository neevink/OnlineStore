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
            #region Роли
            Role admin = new Role() { Id = RoleEnum.Admin, Name = "Администратор" };
            Role customer = new Role() { Id = RoleEnum.Customer, Name = "Покупатель" };

            db.Roles.AddRange(new Role[] { admin, customer });
            #endregion

            #region Цвета
            Color white = new Color() { Name = "Белый" };
            Color oak = new Color() { Name = "Дуб" };
            Color black = new Color() { Name = "Чёрный" };

            db.Colors.AddRange(new Color[] { white, oak, black });
            #endregion

            #region Категории
            Category otherCategory = new Category();
            otherCategory.Name = "Другое";
            Category tablesCategory = new Category();
            tablesCategory.Name = "Столы";
            Category chairsCategory = new Category();
            chairsCategory.Name = "Стулья";
            Category wardrobesCategory = new Category();
            wardrobesCategory.Name = "Шкафы";

            db.Categories.AddRange(new Category[]{otherCategory, tablesCategory, chairsCategory, wardrobesCategory});

            #endregion

            #region Товары
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
                MainImage = GetImageBytesFromPath(@"E:\VisualStudioProjects\OnlineStore\OnlineStore\Content\melltorp-stol.jpg"),
                Category = tablesCategory
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
                MainImage = GetImageBytesFromPath(@"E:\VisualStudioProjects\OnlineStore\OnlineStore\Content\eggelstad-chair.jpg"),
                Category = chairsCategory
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
                MainImage = GetImageBytesFromPath(@"E:\VisualStudioProjects\OnlineStore\OnlineStore\Content\rakkestad-wardrobe.jpg"),
                Category = wardrobesCategory
            };

            db.Products.AddRange(new Product[] { table, chair, wardrobe });
            #endregion

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