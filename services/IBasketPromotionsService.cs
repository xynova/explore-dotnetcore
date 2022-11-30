using System;
using Domain.Services.Promotions;

public interface IBasketPromotionsService {
    BasketPromotion CalculatePromotionsForBasket(BasketOrder basket);

}