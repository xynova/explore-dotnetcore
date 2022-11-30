using api.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Promotions;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketPromotionsController : ControllerBase
{

    readonly ILogger<BasketPromotionsController> _logger;
    readonly IBasketPromotionsService _basketPromotionsService ;
    readonly IBasketProductsService _basketProductsService;

    public BasketPromotionsController(ILogger<BasketPromotionsController> logger
        , IBasketPromotionsService basketPromotionsService
        , IBasketProductsService basketProductsService)
    {
        if(basketPromotionsService == null)
            throw new ArgumentNullException("Argument basketPromotionsService cannot be null");

        if(basketProductsService == null)
            throw new ArgumentNullException("Argument basketProductsService cannot be null");

        _logger = logger;
        _basketPromotionsService = basketPromotionsService;
        _basketProductsService = basketProductsService;
    }

    [HttpPost(Name = "BasketPromotions")]
    public IActionResult Post([FromBody] CustomerBasket customerBasket)
    {
        if (customerBasket == null)
            return BadRequest("The basket cannot be empty");

        var productItemsMap = _basketProductsService.GetProductItemsByIdList(customerBasket.Basket.Select(x=>x.ProductId))
            .ToDictionary(x=> x.Id, x=> x);

        var basketOrder = new BasketOrder(customerBasket.CustomerId, customerBasket.LoyaltyCard, customerBasket.TransactionDate);
        foreach(var item in customerBasket.Basket){
            if(!productItemsMap.ContainsKey(item.ProductId)){
                return BadRequest($"The product {item.ProductId} does not exist.");
            }

            basketOrder.AddItem(productItemsMap[item.ProductId], item.Quantity);
        }
        
        var rt = _basketPromotionsService.CalculatePromotionsForBasket(basketOrder);

       return Ok(
            new ApplicableBasketPromotion{
                CustomerId = rt.Basket.CustomerId,
                LoyaltyCard = rt.Basket.LoyaltyCardId,
                TransactionDate = DateOnly.FromDateTime(rt.DateCreated),
                TotalAmount = rt.Basket.GetSubTotal(),
                DiscountApplied = rt.GetDiscountsSubtotal(),
                GrandTotal = rt.Basket.GetSubTotal() - rt.GetDiscountsSubtotal(),
                PointsEarned = rt.GetEarnedPoints(),
            }
        );
    }
}
