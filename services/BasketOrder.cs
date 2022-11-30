using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Promotions;

public class BasketOrder {

    Dictionary<String,BasketOrdertEntry> _items = new Dictionary<String,BasketOrdertEntry>();
    String _customerId;
    String _loyaltyCardId;
    DateOnly _transactionDate;

    public BasketOrder(String customerId, String loyaltyCardId, DateOnly transactionDate){
        _customerId = customerId ?? String.Empty;
        _loyaltyCardId = loyaltyCardId ?? String.Empty;
        _transactionDate = transactionDate;
    }

    public BasketOrdertEntry[] Entry{
        get{ return this._items.Values.ToArray(); }
    }
    public String CustomerId {
        get{ return this._customerId; }
    }
    public String LoyaltyCardId { 
        get{ return this._loyaltyCardId; } 
    }

     public DateOnly TransactionDate { 
        get{ return this._transactionDate; } 
    }

    public void AddItem(ProductItem item , Int32 quantity){
        _items[item.Id] = new BasketOrdertEntry(item, quantity);
    }

    public Double GetSubTotal(){
        return _items.Values.Sum(x => x.Product.UnitPrice * x.Quantity);
    }

}

