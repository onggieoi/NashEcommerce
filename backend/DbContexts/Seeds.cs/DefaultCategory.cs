using System.Threading.Tasks;
using backend.Models;

namespace backend.DbContexts.Seeds
{
    public static class DefaultData
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            var secrumCate = new Category
            {
                Name = "Natural Serum",
                Image = "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-1.jpg",
                Description = "The best secrum to help your face more better natural",
            };

            var waterCate = new Category
            {
                Name = "Natural Water",
                Image = "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-6.jpg",
                Description = "Hydration can help lubricate and cushion joints, protect sensitive tissues in your body, flush out waste and keep your immune system and even your skin healthy.",
            };

            var lifeCate = new Category
            {
                Name = "Healthy Life",
                Image = "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-9.jpg",
                Description = "To maintain a healthy lifestyle, you need to keep eating healthy. Add more fruits and vegetables in your diet and eat less carbohydrates, high sodium and unhealthy fat. Avoid eating junk food and sweets. Avoid skipping a meal—this will only make your body crave more food the moment you resume eating.",
            };

            await dbContext.Categories.AddRangeAsync(secrumCate, waterCate, lifeCate);
            await dbContext.SaveChangesAsync();

            var secrumProducts = new Product[] {
                new Product {
                    Name = "Blue Ocean Secrum",
                    Price = 300,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-1.jpg",
                    Description= "Provide skin with nutrients, antioxidants and moisture with La Roche-Posay face moisturizers. Ranging from lightweight face lotions to rich moisturizing face creams, our moisturizers for face are formulated for a variety of skin types and concerns including dry skin, oily skin, acne, anti-aging, and UV protection.",
                    CategoryId = secrumCate.CategoryId,
                },
                new Product {
                    Name = "Comistic Effaclar",
                    Price = 320,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-3.jpg",
                    Description= "Provide skin with nutrients, antioxidants and moisture with La Roche-Posay face moisturizers. Ranging from lightweight face lotions to rich moisturizing face creams, our moisturizers for face are formulated for a variety of skin types and concerns including dry skin, oily skin, acne, anti-aging, and UV protection.",
                    CategoryId = secrumCate.CategoryId,
                },
                new Product {
                    Name = "Pure Vitamin C Face Secrum",
                    Price = 350,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-4.jpg",
                    Description= "Provide skin with nutrients, antioxidants and moisture with La Roche-Posay face moisturizers. Ranging from lightweight face lotions to rich moisturizing face creams, our moisturizers for face are formulated for a variety of skin types and concerns including dry skin, oily skin, acne, anti-aging, and UV protection.",
                    CategoryId = secrumCate.CategoryId,
                }
            };

            var waterProducts = new Product[] {
                new Product {
                    Name = "Orange Juice Water",
                    Price = 40,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-2.jpg",
                    Description= "Hydration can help lubricate and cushion joints, protect sensitive tissues in your body, flush out waste and keep your immune system and even your skin healthy. It turns out that might come down to personal preference, as more research seems to be needed for a definitive answer.",
                    CategoryId = waterCate.CategoryId,
                },
                new Product {
                    Name = "Cocooil Water",
                    Price = 55,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-6.jpg",
                    Description= "Hydration can help lubricate and cushion joints, protect sensitive tissues in your body, flush out waste and keep your immune system and even your skin healthy. It turns out that might come down to personal preference, as more research seems to be needed for a definitive answer.",
                    CategoryId = waterCate.CategoryId,
                },
                new Product {
                    Name = "AquaPanana",
                    Price = 20,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-7.jpg",
                    Description= "Hydration can help lubricate and cushion joints, protect sensitive tissues in your body, flush out waste and keep your immune system and even your skin healthy. It turns out that might come down to personal preference, as more research seems to be needed for a definitive answer.",
                    CategoryId = waterCate.CategoryId,
                }
            };

            var lifeProducts = new Product[] {
                new Product {
                    Name = "Aerin Perfom",
                    Price = 360,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-5.jpg",
                    Description= "being healthy means being mentally and emotionally fit. Being healthy should be part of your overall lifestyle. Living a healthy lifestyle can help prevent chronic diseases and long-term illnesses. Feeling good about yourself and taking care of your health are important for your self-esteem and self-image. Maintain a healthy lifestyle by doing what is right for your body.",
                    CategoryId = lifeCate.CategoryId,
                },
                new Product {
                    Name = "Fresher Views",
                    Price = 240,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-8.jpg",
                    Description= "being healthy means being mentally and emotionally fit. Being healthy should be part of your overall lifestyle. Living a healthy lifestyle can help prevent chronic diseases and long-term illnesses. Feeling good about yourself and taking care of your health are important for your self-esteem and self-image. Maintain a healthy lifestyle by doing what is right for your body.",
                    CategoryId = lifeCate.CategoryId,
                },
                new Product {
                    Name = "Cookies",
                    Price = 110,
                    Image= "https://onggieoi.blob.core.windows.net/firstcontainer/portfolio-9.jpg",
                    Description= "being healthy means being mentally and emotionally fit. Being healthy should be part of your overall lifestyle. Living a healthy lifestyle can help prevent chronic diseases and long-term illnesses. Feeling good about yourself and taking care of your health are important for your self-esteem and self-image. Maintain a healthy lifestyle by doing what is right for your body.",
                    CategoryId = lifeCate.CategoryId,
                }
            };

            await dbContext.Products.AddRangeAsync(secrumProducts);
            await dbContext.Products.AddRangeAsync(waterProducts);
            await dbContext.Products.AddRangeAsync(lifeProducts);
            await dbContext.SaveChangesAsync();
        }
    }
}