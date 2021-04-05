namespace client.Constants
{
    public static class EndPoints
    {
        public const string Category = "api/categories";
        public const string Product = "api/products";
        public const string Rate = "api/rates";
        public static string GetProductById(int id) => $"{Product}/{id}";
        public static string GetProductByCategory(int categoryId) => $"{Product}/?categoryId={categoryId}";
    }
}