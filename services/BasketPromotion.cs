using System;
using System.Linq;

namespace Domain.Services.Promotions;

public class BasketPromotion {

    
    BasketOrder _basket; 
    DateTime _dateCreated;
    IOrderDiscount[] _applicableDiscounts;
    IOrderPoints[] _applicablePoints;

    public BasketPromotion(BasketOrder basket, IOrderDiscount[] applicableDiscounts, IOrderPoints[] applicablePoints){
        if(basket == null)
            throw new ArgumentNullException($"Argument {nameof(basket)} cannot be null");

        _basket = basket;
        _applicableDiscounts = applicableDiscounts ?? new IOrderDiscount[0] ;
        _applicablePoints = applicablePoints ?? new IOrderPoints[0] ;
        _dateCreated = DateTime.Now;
    }

    public DateTime DateCreated { 
        get{ return _dateCreated; }
    }
    public BasketOrder Basket { 
        get{ return _basket; }
    }
    public IOrderDiscount[] ApplicableDiscounts { 
        get{ return _applicableDiscounts; }
    }
    public IOrderPoints[] ApplicablePoints { 
        get{ return _applicablePoints; }
    }

    public Double GetDiscountsSubtotal() {
        return _applicableDiscounts.Sum(x=> x.Amount );
    }
    public Int32 GetEarnedPoints() {
        return _applicablePoints.Sum(x=> x.Points );
    }
    

   
}

