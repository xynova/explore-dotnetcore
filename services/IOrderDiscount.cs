using System;

namespace Domain.Services.Promotions;

public interface IOrderDiscount {

    String Id { get; }

    String Name  {get;}

    Double Amount { get; }
}

public interface IOrderDiscountPromotion : IOrderDiscount{

    DateOnly StartDate {get;}

    DateOnly EndDate {get;}
}


