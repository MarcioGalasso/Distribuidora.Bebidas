
using FluentValidation;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            // Itens obrigatórios
            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage(Resources.OrderResource.NotEmptyItems);

            // Quantidade mínima de itens no total
            RuleFor(x => x.Items.Sum(i => i.Amount))
                .GreaterThanOrEqualTo(1000)
                .WithMessage(Resources.OrderResource.MinAmountItems);

            // Valida cada item individualmente
            RuleForEach(x => x.Items).ChildRules(items =>
            {
                // Amount deve ser maior que 0
                items.RuleFor(i => i.Amount)
                    .GreaterThan(0)
                    .WithMessage(Resources.OrderResource.ItemAmountGreaterThanZero);

                // SKU obrigatório
                items.RuleFor(i => i.SKU)
                    .NotEmpty()
                    .WithMessage(Resources.OrderResource.ItemSkuRequired);
            });

            // Endereço de entrega obrigatório
            RuleFor(x => x.IdDeliveryAddress)
                .NotEqual(Guid.Empty)
                .WithMessage(Resources.OrderResource.DeliveryAddressRequired);

            RuleFor(x => x.IdResale)
        .NotEqual(Guid.Empty)
        .WithMessage(Resources.OrderResource.ResaleRequired);
        }
    }
}