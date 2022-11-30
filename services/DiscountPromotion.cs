namespace services;

public class DiscountPromotion : IPromotion
{
    public string Identifier => throw new NotImplementedException();

    public string Name => throw new NotImplementedException();

    public DateOnly StartDate => throw new NotImplementedException();

    public DateOnly EndDate => throw new NotImplementedException();

    Double DiscountPercent { get; }
}
