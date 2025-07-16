
using Domain.Contracts;
using System.Text.Json;

namespace Persistance.Data.DataSeeding
{
    public class DbIntializer(AppDbContext dbContext) : IDbIntializer
    {
        private AppDbContext _dbContext = dbContext;

        public async Task IntializeAsync()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    await _dbContext.Database.MigrateAsync();

                    if (!_dbContext.ProductTypes.Any())
                    {
                        
                        var TypesData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeeding\types.json");

                        //Convert data from jason to c# objects

                        var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                        if (TypesData.Any() && TypesData is not null) 
                        { 
                            await _dbContext.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                        }

                    if (!_dbContext.ProductBrands.Any())
                    {
                        var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeeding\brands.json");

                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                        if (brandsData is not null && brandsData.Any())
                        {
                            await _dbContext.AddRangeAsync(brands);
                            await _dbContext.SaveChangesAsync();
                } 
                    }
                
                if (!_dbContext.Products.Any())
                    {
                        var     ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeeding\Products.json");

                        var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                        if (ProductsData is not null && ProductsData.Any())
                        {
                            await _dbContext.AddRangeAsync(Products);
                            await _dbContext.SaveChangesAsync();
                        }
                    
                       }
             

            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
