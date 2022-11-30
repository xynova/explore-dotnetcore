using System;
using System.Collections.Generic;
using Domain.Services.Promotions;

public interface IBasketProductsService {
    ProductItem[] GetProductItemsById(IEnumerable<String> idList);

}