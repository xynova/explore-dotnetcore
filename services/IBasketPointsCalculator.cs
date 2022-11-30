using Domain.Services.Promotions;
public interface IBasketPointsCalculator{
    IOrderPoints[]  CalculatePoints(BasketOrder basket);
}



