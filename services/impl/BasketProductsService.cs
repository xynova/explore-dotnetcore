using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Promotions.Impl;

public class BasketProductsService : IBasketProductsService
{

    public ProductItem[] GetProductItemsById(IEnumerable<string> idList)
    {
        var uniqueIds = new HashSet<String> (idList ?? new String[0]);

        // should call into a real datastore
        return this.GetAllItems()
            .Where(x=> uniqueIds.Contains(x.Id))
            .ToArray();
    }


    ProductItem[] GetAllItems() {

        return new ProductItem[]{
            new ProductItem{
                Id = "PRD01",
                Name = "Vortex 95",
                Category = "Fuel",
                UnitPrice = 1.2,
            },
            new ProductItem{
                Id = "PRD02",
                Name = "Vortex 98",
                Category = "Fuel",
                UnitPrice = 1.3,
            },
            new ProductItem{
                Id = "PRD03",
                Name = "Diesel",
                Category = "Fuel",
                UnitPrice = 1.1,
            },
            new ProductItem{
                Id = "PRD04",
                Name = "Twix 55g",
                Category = "Shop",
                UnitPrice = 2.3,
            },
            new ProductItem{
                Id = "PRD05",
                Name = "Mars 72g",
                Category = "Shop",
                UnitPrice = 5.1,
            },
            new ProductItem{
                Id = "PRD06",
                Name = "SNICKERS 72G",
                Category = "Shop",
                UnitPrice = 3.4,
            },
            new ProductItem{
                Id = "PRD07",
                Name = "Bounty 3 63g",
                Category = "Shop",
                UnitPrice = 6.9,
            },
            new ProductItem{
                Id = "PRD08",
                Name = "Snickers 50g",
                Category = "Shop",
                UnitPrice = 4.0,
            },
        };   
    }
}



 
 