using System;

namespace Domain.Services.Promotions;

public class BasketOrdertEntry{

    ProductItem _product; 
    Int32 _quantity;

    public BasketOrdertEntry(ProductItem product, Int32 quantity){

        if (product == null)
            throw new ArgumentNullException("product cannot be null");

        _product = product;

        if (quantity > 0)
            _quantity = quantity;

    }

    public ProductItem Product{ 
        get{ return _product; } 
    }
    public Int32 Quantity{
        get{ return _quantity; } 
    }
}

