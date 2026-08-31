using System.ComponentModel.DataAnnotations;

namespace ShopFlow.Features.Products.GetProduct
{
    public class GetProductRequest
    {
        [Range(1,int.MaxValue)]
        public int ProductId { get; set; }
    }
}
