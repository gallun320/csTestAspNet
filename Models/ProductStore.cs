using CsTesAspNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CsTesAspNet.Models 
{
    public class ProductStore
    {
        public void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new ProductContext(serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
            {
                if(context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                                        new Product { Name = "test1", Cost = 1 }, 
                                        new Product { Name = "test2", Cost = 2 }, 
                                        new Product { Name = "test3", Cost = 3 }
                                        );

                context.SaveChanges();
            }
        }
    }
}