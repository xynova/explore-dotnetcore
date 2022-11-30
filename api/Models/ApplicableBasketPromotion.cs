using System.Text.Json.Serialization;

namespace api.Models;

public class ApplicableBasketPromotion {
     
    public String CustomerId { get;set ;}
    public String LoyaltyCard { get;set ;}

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly TransactionDate{ get;set ;}

    [JsonConverter(typeof(DecimalJsonConverter))]
    public Double TotalAmount{ get;set ;}

    [JsonConverter(typeof(DecimalJsonConverter))]
    public Double DiscountApplied { get;set ;}

    [JsonConverter(typeof(DecimalJsonConverter))]
    public Double GrandTotal{ get;set ;}
    public Int32 PointsEarned{ get;set ;}

}