using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.Entities;
using ShopOnlineApi.Repositories.Contracts;
namespace ShopOnlineApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;
       

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

        async Task<IEnumerable<ProductCategory>> IProductRepository.GetCategories()
        {
         return await this.shopOnlineDbContext.ProductCategories.ToListAsync();
          
           
        }

         public   async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

       public async Task<Product> GetProduct(int id)
        {
            var product = await this.shopOnlineDbContext.Products.FindAsync(id);
            return product;
        }

       public async Task<IEnumerable<Product>> GetProducts()
        {
          var products= await this.shopOnlineDbContext.Products.ToListAsync();
            return products;

        }
    }
}

