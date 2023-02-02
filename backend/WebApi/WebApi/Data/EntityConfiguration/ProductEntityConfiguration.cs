using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entities;

namespace WebApi.Data.EntityConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.Consist).IsRequired();

            builder.HasOne(h => h.Category)
                .WithMany(h => h.Products)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                    new ProductEntity
                    {
                        Id = 1,
                        Title = "Pizza Saint Diablo",
                        CategoryId = 1,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2021/04/svjatoi-diablo-1.jpg.webp",
                        Price = 245,
                        Consist = "mozzarella, mushrooms, salami, pesto sauce, tomato sauce, oregano",
                        Weight = 870
                    },
                    new ProductEntity
                    {
                        Id = 2,
                        Title = "Pepperoni",
                        CategoryId = 1,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2014/08/pepperoni.jpg.webp",
                        Price = 235,
                        Consist = "Pepperoni, hunting sausages, feta, olives, sriracha, mozzarella, oregano, tomato sauce",
                        Weight = 800
                    },
                    new ProductEntity
                    {
                        Id = 3,
                        Title = "Pizza Boom of meat",
                        CategoryId = 1,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2014/08/mjasnoj-bum.jpg.webp",
                        Price = 245,
                        Consist = "mozzarella, hunting sausages, bacon, boiled pork, blue onion, tomato sauce, parsley, oregano",
                        Weight = 850
                    },
                    new ProductEntity
                    {
                        Id = 4,
                        Title = "European",
                        CategoryId = 1,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2014/08/evropejskaja.jpg.webp",
                        Price = 149,
                        Consist = "mozzarella, chicken fillet, hunting sausages, champignons, parsley, ham, tomato sauce, oregano",
                        Weight = 550
                    },
                    new ProductEntity
                    {
                        Id = 5,
                        Title = "Seafood",
                        CategoryId = 1,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2014/08/dary-morja.jpg.webp",
                        Price = 229,
                        Consist = "mozzarella, salmon, mussels, squid, tomato, lemon, pesto, oregano, tomato sauce",
                        Weight = 550
                    },
                    new ProductEntity
                    {
                        Id = 6,
                        Title = "Pizza with ham and mushrooms",
                        CategoryId = 1,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2015/09/vechtchina-griby.jpg.webp",
                        Price = 239,
                        Consist = "mozzarella, ham, olives, tomatoes, parsley, mushrooms, oregano, tomato sauce",
                        Weight = 900
                    },
                    new ProductEntity
                    {
                        Id = 7,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2014/08/tropikano-1.jpg.webp",
                        Title = "Pizza Life",
                        Price = 285,
                        Weight = 900,
                        Consist = "mozzarella, pineapple, chicken fillet, oregano, parsley, tomato sauce",
                        CategoryId = 1
                    },
                    new ProductEntity
                    {
                        Id = 8,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2021/04/vegetarianskaja-nju.jpg.webp",
                        Title = "Vegetarian",
                        Price = 159,
                        Weight = 550,
                        Consist = "Feta, mozzarella, broccoli, olives, olives, bell peppers, tomatoes, mars onion, oregano, tomato sauce",
                        CategoryId = 1
                    },
                    new ProductEntity
                    {
                        Id = 9,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2014/08/sbornaja-mjasnaja.jpg.webp",
                        Title = "Team Meat",
                        Price = 245,
                        Weight = 850,
                        Consist = "mozzarella, boiled pork, salami, hunting sausages, ham, bacon, olives, oregano, tomato sauce",
                        CategoryId = 1
                    },
                    new ProductEntity
                    {
                        Id = 10,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2015/09/4-syra.jpg.webp",
                        Title = "4 Cheeses",
                        Price = 210,
                        Weight = 450,
                        Consist = "mozzarella, dorblu cheese, parmesan, hard cheese, bechamel sauce, oregano",
                        CategoryId = 1
                    },
                    new ProductEntity
                    {
                        Id = 11,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/2-dabl-panch-169-245-grn.jpg.webp",
                        Title = "Double Punch",
                        Price = 169,
                        Weight = 500,
                        Consist = "ham, salami, Parmesan cheese, hard cheese, mozzarella, Dorblu cheese, mushrooms, tomatoes, Bechamel sauce, tomato sauce",
                        CategoryId = 1
                    },
                    new ProductEntity
                    {
                        Id = 12,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2021/04/4-mjasa-1.jpg.webp",
                        Title = "4 Meats",
                        Price = 240,
                        Weight = 750,
                        Consist = "Veal sous-vide, salami, hunting sausages, chicken fillet, Dorblu cheese, parmesan, mozzarella, hard cheese, oregano, tomato sauce",
                        CategoryId = 1
                    },
                    new ProductEntity
                    {
                        Id = 13,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/134-vilnii-165.jpg.webp",
                        Title = "Free",
                        Price = 165,
                        Weight = 230,
                        Consist = "butter, takuan, cucumber, bell pepper, mayonnaise",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 14,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/127-krevetkovi-kulki-199.jpg.webp",
                        Title = "Shrimp Balls",
                        Price = 199,
                        Weight = 240,
                        Consist = "salmon, shrimps, cream cheese, cucumber, spice sauce, batter, panko crackers",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 15,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/102-gavaiskii-159-grn.jpg.webp",
                        Title = "Hawaiian",
                        Price = 159,
                        Weight = 290,
                        Consist = "smoked chicken, cream cheese, pineapple, mayonnaise, cheddar cheese, unagi sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 16,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/93-spring-fish-165-grn.jpg.webp",
                        Title = "Spring Fish",
                        Price = 165,
                        Weight = 200,
                        Consist = "smoked salmon, chuka, cucumber, bell pepper, iceberg lettuce, cheddar cheese, spice sauce, french onion",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 17,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/50-unagi-kranch-219-grn.jpg.webp",
                        Title = "Unagi Crunch",
                        Price = 219,
                        Weight = 300,
                        Consist = "cocktail shrimp, salmon, takuan, pumpkin, cream cheese, batter, panko crackers, spice sauce, unagi sauce, peanuts",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 18,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/57-4-ribi-275-grn-ot-shefa.jpg.webp",
                        Title = "4 Fishes",
                        Price = 275,
                        Weight = 300,
                        Consist = "panko shrimp, eel, salmon, tuna, tiger shrimp, cream cheese, iceberg lettuce, scrambled eggs, spice sauce, unagi sauce, nachos",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 19,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/68-losos-na-grili-225-grn.jpg.webp",
                        Title = "Grilled Salmon",
                        Price = 225,
                        Weight = 300,
                        Consist = "salmon, takuan, scrambled eggs, nachos, mayonnaise, cheddar cheese, unag sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 20,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/134-vilnii-165.jpg.webp",
                        Title = "Vegetus",
                        Price = 119,
                        Weight = 220,
                        Consist = "pumpkin, takuan, chuka, bell pepper, cream cheese",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 21,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/06/2-vulkan-900h600.jpg.webp",
                        Title = "Volcano",
                        Price = 185,
                        Weight = 290,
                        Consist = "salmon, snow crab, cream cheese, cucumber, scrambled eggs, tempura, panko crackers, spice sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 22,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/06/kopchenyj-losos-900h600-2.jpg.webp",
                        Title = "Tempura Mix Fish",
                        Price = 225,
                        Weight = 280,
                        Consist = "cream cheese, salmon sous-vide, pink salmon, butterfish, cucumber, panko crackers, green onion, tempura, spice sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 23,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2021/12/unagi-grin.jpg.webp",
                        Title = "Philadelphia Unagi Green",
                        Price = 145,
                        Weight = 225,
                        Consist = "unagi perch, cream cheese, cucumber, unagi sauce, spice sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 24,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/09/zapechena-filadelfija-nova-2.jpg.webp",
                        Title = "Baked Philadelphia",
                        Price = 159,
                        Weight = 260,
                        Consist = "salmon, cream cheese, pear, cheddar cheese, mayonnaise, sriracha sauce, unagi sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 25,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/06/3-dabl-chiz-900h600.jpg.webp",
                        Title = "Double Cheese",
                        Price = 179,
                        Weight = 235,
                        Consist = "smoked salmon, scrambled eggs, toaster cheese, cream cheese, cucumber, spice sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 26,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/08/zapechennaja-kurochka-grusha.jpg.webp",
                        Title = "Baked Chicken Pear",
                        Price = 159,
                        Weight = 310,
                        Consist = "chicken, cream cheese, pear, cheddar cheese, mayonnaise, sesame, french onion, sriracha sauce, unagi sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 27,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2016/02/unagi-tempura-2.jpg.webp",
                        Title = "Unagi Tempura",
                        Price = 185,
                        Weight = 280,
                        Consist = "unagi perch, salmon, cream cheese, panko crackers, tempura batter, unagi sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 28,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/08/zapechennyj-losos.jpg.webp",
                        Title = "Baked Salmon",
                        Price = 199,
                        Weight = 290,
                        Consist = "salmon, cream cheese, scrambled eggs, cheddar cheese, mayonnaise, sesame, sriracha sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 29,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/08/bayraktar-new.jpg.webp",
                        Title = "Bayraktar",
                        Price = 155,
                        Weight = 210,
                        Consist = "salmon sous-vide, bell pepper, cucumber, cream cheese, Cheddar cheese, spice sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 30,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2021/01/filadelfiya-xl.jpg.webp",
                        Title = "Philadelphia XL",
                        Price = 225,
                        Weight = 310,
                        Consist = "salmon, cream cheese, avocado, cucumber",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 31,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2022/06/11-jamamoto-900h600-1.jpg.webp",
                        Title = "Yamamoto",
                        Price = 275,
                        Weight = 305,
                        Consist = "salmon, snow crab, cucumber, takuan, campio, cream cheese, sauce",
                        CategoryId = 2
                    },
                    new ProductEntity
                    {
                        Id = 32,
                        Img = "https://roll-club.kh.ua/wp-content/uploads/2021/12/unagi-lajt.jpg.webp",
                        Title = "Philadelphia Unagi Light",
                        Price = 149,
                        Weight = 210,
                        Consist = "unagi perch, cream cheese, cucumber, unagi sauce, sesame",
                        CategoryId = 2
                    });
        }
    }
}
