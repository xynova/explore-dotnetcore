namespace services;

public class BasketOrder {

    Dictionary<String,BasketOrdertEntry> _items = new Dictionary<String,BasketOrdertEntry>();
    String _customerId;
    String _loyaltyCardId;

    public BasketOrder(String customerId, String loyaltyCardId){
        _customerId = customerId ?? String.Empty;
        _loyaltyCardId = loyaltyCardId ?? String.Empty;
    }

    public BasketOrdertEntry[] Items{
        get{ return this._items.Values.ToArray(); }
    }
    public String CustomerId {
        get{ return this._customerId; }
    }
    public String LoyaltyCardId { 
        get{ return this._loyaltyCardId; } 
    }

    public void AddItem(ProductItem item , Int32 quantity){
        _items[item.Id] = new BasketOrdertEntry(item, quantity);
    }

    public Double GetSubTotal(){
        return _items.Values.Sum(x => x.Product.UnitPrice * x.Quantity);
    }

}

