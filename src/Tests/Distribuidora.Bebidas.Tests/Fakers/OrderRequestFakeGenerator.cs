using Bogus;
using Distribuidora.Bebidas.Domain.ViewModel.Order;

public static class OrderRequestFakeGenerator
{
    public static OrderRequest GenerateFakeSuccess()
    {
        var faker = new Faker<OrderRequest>()
         .RuleFor(c => c.IdResale, f => f.Random.Guid())
         .RuleFor(c => c.IdDeliveryAddress, f => f.Random.Guid())
         .RuleFor(c => c.Items, f => GenerateItens(5))
         .RuleFor(c => c.Request, f => DateTime.Now);
        return faker.Generate();
    }

    public static OrderRequest GenerateFakeErrorAmount()
    {

        var faker = new Faker<OrderRequest>()
        .RuleFor(c => c.IdResale, f => f.Random.Guid())
        .RuleFor(c => c.IdDeliveryAddress, f => f.Random.Guid())
        .RuleFor(c => c.Items, f => GenerateItens(2))
        .RuleFor(c => c.Request, f => DateTime.Now);
        return faker.Generate();

    }
    public static OrderRequest GenerateFakeErrorIdResale()
    {

        var faker = new Faker<OrderRequest>()
        .RuleFor(c => c.IdDeliveryAddress, f => f.Random.Guid())
        .RuleFor(c => c.Items, f => GenerateItens(2))
        .RuleFor(c => c.Request, f => DateTime.Now);
        return faker.Generate();

    }

    public static OrderRequest GenerateFakeErrorIdAdress()
    {

        var faker = new Faker<OrderRequest>()
        .RuleFor(c => c.IdResale, f => f.Random.Guid())
        .RuleFor(c => c.Items, f => GenerateItens(2))
        .RuleFor(c => c.Request, f => DateTime.Now);
        return faker.Generate();

    }
    public static List<ItemsRequest> GenerateItens(int amount = 1)
    {
        var faker = new Faker<ItemsRequest>()
        .RuleFor(c => c.SKU, f => f.Commerce.ProductAdjective())
        .RuleFor(c => c.Amount, f => f.Commerce.Random.Int(200, 500))
        .RuleFor(c => c.Description, f => f.Commerce.ProductDescription());
        return faker.Generate(amount);

    }
}



