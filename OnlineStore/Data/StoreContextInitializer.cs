using OnlineStore.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
            Color pine = new Color() { Name = "Сосна" };

            db.Colors.Add(white);
            db.Colors.Add(oak);
            db.Colors.Add(pine);

            /*
            Product table = new Product()
            {
                SKU = "392.271.68",
                Name = "Стол MELLTORP МЕЛЬТОРП",
                Description = "Этот стол подойдет любому — от одинокого любителя минимализма до большой шумной семьи с детьми, которые все проверяют на прочность. Его можно поставить на кухню или в столовую, а его лаконичный дизайн будет гармонично сочетаться с самыми разными стилями.",
                Color = white,
                Width = 75,
                Length = 75,
                Hight = 74,

                StockQuantity = 10,
                Price = 34
            };

            db.Products.Add(table);
            */
            db.SaveChanges();
        }
    }
}