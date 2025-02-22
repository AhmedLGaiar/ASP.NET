namespace Day1.Models
{
    public class ProductsBL
    {
        private List<Products> products;
        public ProductsBL()
        {
            products = new List<Products>();

            products.Add(new Products()
            {
                Id = 1,
                Name = "MSI Laptop 2060 RTX",
                Price = 50000,
                Type = "Laptops",
                Category = "Electronics",
                img = "1.jpeg"
            });
            products.Add(new Products()
            {
                Id = 2,
                Name = "Dell XPS 15",
                Price = 60000,
                Type = "Laptops",
                Category = "Electronics",
                img = "2.jpeg"

            });
            products.Add(new Products()
            {
                Id = 3,
                Name = "MacBook Pro",
                Price = 80000,
                Type = "Laptops",
                Category = "Electronics",
                img = "3.jpeg"

            });
            products.Add(new Products()
            {
                Id = 4,
                Name = "Lenovo Legion 5",
                Price = 45000,
                Type = "Gaming Laptops",
                Category = "Electronics",
                img = "4.jpeg"

            });
            products.Add(new Products()
            {
                Id = 5,
                Name = "HP Spectre x360",
                Price = 55000,
                Type = "Laptops",
                Category = "Electronics",
                img = "5.jpeg"

            });
            products.Add(new Products()
            {
                Id = 6,
                Name = "Asus ROG Zephyrus",
                Price = 70000,
                Type = "Gaming Laptops",
                Category = "Electronics",
                img = "6.jpeg"

            });
            products.Add(new Products()
            {
                Id = 7,
                Name = "Acer Predator Helios",
                Price = 65000,
                Type = "Gaming Laptops",
                Category = "Electronics",
                img = "7.jpeg"
            });
            products.Add(new Products()
            {
                Id = 8,
                Name = "Razer Blade 15",
                Price = 90000,
                Type = "Gaming Laptops",
                Category = "Electronics",
                img = "8.jpeg"
            });
            products.Add(new Products()
            {
                Id = 9,
                Name = "Gigabyte AERO 15",
                Price = 75000,
                Type = "Laptops",
                Category = "Electronics",
                img = "9.jpeg"
            });
            products.Add(new Products()
            {
                Id = 10,
                Name = "Microsoft Surface Laptop",
                Price = 50000,
                Type = "Laptops",
                Category = "Electronics",
                img = "10.jpeg"
            });
        }
        public List<Products> GetAll()
        {
            return products;
        }
        public Products GetByID(int id)
        {
            return products.FirstOrDefault(s => s.Id == id);
        }
    }
}
