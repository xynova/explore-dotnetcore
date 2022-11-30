namespace services;

public interface IOrderDiscount {

    string Id { get; }

    string Name  {get;}

    Double Amount { get; }
}

public interface IOrderDiscountPromotion : IOrderDiscount{

    DateOnly StartDate {get;}

    DateOnly EndDate {get;}
}


public interface IOrderPoints {

    string Id { get; }

    string Name  {get;}

    Int32 Points { get; }
}

public interface IOrderPointsPromotion {

    DateOnly StartDate {get;}

    DateOnly EndDate {get;}
}