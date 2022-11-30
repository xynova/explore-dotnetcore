using System;

namespace Domain.Services.Promotions.Impl;

public class BasketPromotionsService : IBasketPromotionsService
{


    public BasketPromotion CalculatePromotionsForBasket(BasketOrder basket){

        // var rt = new BasketPromotion();


        return new BasketPromotion(basket, null, null);
    }

   
}
