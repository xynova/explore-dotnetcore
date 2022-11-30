using System;

namespace Domain.Services.Promotions.Impl;

public class DefaultBasketPointsCalculator : IBasketPointsCalculator
{
    public IOrderPoints[] CalculatePoints(BasketOrder basket)
    {
        if(basket == null)
            throw new ArgumentNullException($"Argument {nameof(basket)} cannot be null");
            
        return new IOrderPoints[0];
    }
}