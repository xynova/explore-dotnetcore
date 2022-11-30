using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Promotions.Impl;

public class BasketProductsDiscountsCalculator : IBasketDiscountsCalculator
{
    public IOrderDiscount[] CalculateDiscounts(BasketOrder basket)
    {
        if(basket == null)
            throw new ArgumentNullException($"Argument {nameof(basket)} cannot be null");

        var rt = new List<IOrderDiscount>();

        DiscountApplier[] appliers = this.GetDiscountAppliersByDate(basket.TransactionDate);

        foreach(var applier in appliers){
            foreach( var entry in basket.Entry){
                if(applier.AppliesToProduct(entry.Product)){
                    var discount = applier.ApplyDiscount(entry.Product, entry.Quantity);
                    rt.Add(discount);
                }
            }
        }

        return rt.ToArray();
    }

    DiscountApplier[] GetDiscountAppliersByDate(DateOnly transactionDate)
    {
        // should call into a real datastore
        return this.GetAllAppliers()
            .Where(x=> x.StartDate <= transactionDate && x.EndDate >= transactionDate )
            .ToArray();
    }

    DiscountApplier[] GetAllAppliers()
    {
        return new DiscountApplier[]{
            new DiscountApplier(
                promotionId: "DP001", 
                promotionName: "Fuel Discount Promo", 
                startDate: DateOnly.ParseExact("01-Jan-2020","dd-MMM-yyyy"),
                endDate: DateOnly.ParseExact("15-Feb-2020","dd-MMM-yyyy"),
                discountPercent: 20,
                new String[]{"PRD02","PRD02"}
            ),
            new DiscountApplier(
                promotionId: "DP001", 
                promotionName: "Fuel Discount Promo", 
                startDate: DateOnly.ParseExact("01-Jan-2020","dd-MMM-yyyy"),
                endDate: DateOnly.ParseExact("15-Feb-2020","dd-MMM-yyyy"),
                discountPercent: 20,
                new String[0]
            ),
        };
    }


    class ProductDiscount : IOrderDiscount
    {
        public String Id { get;set ;}

        public String Name { get;set ;}

        public Double Amount { get;set ;}
    }

    class DiscountApplier
    {
        private readonly HashSet<String> _applicableToProductsSet;

        public DiscountApplier(
            String promotionId, 
            String promotionName, 
            DateOnly startDate, 
            DateOnly endDate, 
            Double discountPercent,
            IEnumerable<String> applicableToProductIds){
            PromotionId = promotionId ?? String.Empty;
            PromotionName = promotionName ?? String.Empty;
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercent = discountPercent;
            _applicableToProductsSet = new HashSet<string>(applicableToProductIds ?? new String[0]);
        }

        public String PromotionId{ get; private set; }
        public String PromotionName{ get; private set; }
        public DateOnly StartDate {get; private set;}
        public DateOnly EndDate {get; private set;}
        public Double DiscountPercent{ get; private set; }
        
        
        public IOrderDiscount ApplyDiscount(ProductItem product, Int32 quantity){
            if(this.AppliesToProduct(product) == false)
                throw new InvalidOperationException($"The discount {this.PromotionName} cannot be applied to {product.Name}");
            
            return new ProductDiscount(){
                Id = this.PromotionId,
                Name = this.PromotionName,
                Amount = (product.UnitPrice * quantity) * (this.DiscountPercent/100)
            };
        }

        public Boolean AppliesToProduct(ProductItem product){
            return _applicableToProductsSet.Contains(product.Id);
        }
    }

}