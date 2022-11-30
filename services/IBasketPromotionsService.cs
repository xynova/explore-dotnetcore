using System;
using Domain.Services.Promotions;

public interface IBasketPromotionsService {
    BasketPromotion CalculateBasketPromotion(BasketOrder basket);
}