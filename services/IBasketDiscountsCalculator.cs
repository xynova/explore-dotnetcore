
using Domain.Services.Promotions;

public interface IBasketDiscountsCalculator{
    IOrderDiscount[] CalculateDiscounts(BasketOrder basket);
}