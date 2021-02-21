using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {

        public static void SeedData(IMongoCollection<Product> productColletion)
        {

            bool existProduct = productColletion.Find(p => true).Any();

            if (!existProduct)
                productColletion.InsertMany(GetPreconfiguredProducts());


        }


        private static IEnumerable<Product> GetPreconfiguredProducts()
        {

            return new List<Product>()
            {

                new Product()
                {
                    Name="Iphone X",
                    Summary = "IPX",
                    Description="asd",
                    ImageFile="product-1.png",
                    Price =  950.00M,
                    Category = "Smart Phone"

                },
                      new Product()
                {
                    Name="Moto G5",
                    Summary = "Moto G",
                    Description="asd",
                    ImageFile="product-2.png",
                    Price =  200.00M,
                    Category = "Smart Phone"

                },
                      new Product()
                {
                    Name="Nexus",
                    Summary = "Nexus",
                    Description="asd",
                    ImageFile="product-3.png",
                    Price =  250.00M,
                    Category = "Smart Phone"

                }

            };

        }


    }
}
