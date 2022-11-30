namespace Domain.Services.Promotions.Impl;

public class BasketPromotionsService : IBasketPromotionsService
{
    private readonly IBasketPointsCalculator _pointsCalc;
    private readonly IBasketDiscountsCalculator _discountsCalc;

    public BasketPromotionsService(IBasketPointsCalculator promotionsCalc, IBasketDiscountsCalculator discountsCalc){
        
        _pointsCalc = promotionsCalc;
        _discountsCalc = discountsCalc;
    }
    

    public BasketPromotion CalculateBasketPromotion(BasketOrder basket){

        var applicableDiscounts = _discountsCalc != null
           ? _discountsCalc.CalculateDiscounts(basket)
           : new IOrderDiscount[0];


        var applicablePoints = _pointsCalc != null 
            ? _pointsCalc.CalculatePoints(basket)
            : new IOrderPoints[0];
        
        return new BasketPromotion(basket, applicableDiscounts, applicablePoints);
    }

   
}
