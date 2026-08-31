namespace ShopFlow.Features.Products.GetProduct
{
    public static class GetProductEndpoint
    {
        private static readonly List<GetProductResponse> Products =
    [
        new GetProductResponse
        {
            Id = 1,
            Name = "Laptop",
            Price = 25000
        },
        new GetProductResponse
        {
            Id = 2,
            Name = "Mouse",
            Price = 500
        },
        new GetProductResponse
        {
            Id = 3,
            Name = "Keyboard",
            Price = 1200
        }
    ];

        public static void MapGetProductEndpoint(this WebApplication app)
        {
            app.MapGet("/api/products/{productId:int}", 
                ([AsParameters]GetProductRequest request) =>
            {
                if (request.ProductId <= 0)
                {
                    return Results.BadRequest("ProductId must be greater than 0.");
                }

                var product = Products.FirstOrDefault(p => p.Id == request.ProductId);

                if (product is null)
                {
                    return Results.NotFound("Product not found.");
                }

                return Results.Ok(product);
            });
        }
    }
}
