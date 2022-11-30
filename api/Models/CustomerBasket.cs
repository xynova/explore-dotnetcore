using System.Text.Json.Serialization;

namespace api.Models;

public class CustomerBasket{
    
    CustomerBasketItem[] _basket = new CustomerBasketItem[0];
    //DateOnly _transactionDate

    public String CustomerId { get;set ;}
    public String LoyaltyCard { get;set ;}

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly TransactionDate{ get;set ;}

    public CustomerBasketItem[] Basket{ 
        get { return _basket; }
        set { _basket = value ?? new CustomerBasketItem[0]; }
    }
}


public class CustomerBasketItem {
    public String ProductId { get; set ;}
    public Double UnitPrice { get; set ;}
    public Int32 Quantity { get; set ;}
}