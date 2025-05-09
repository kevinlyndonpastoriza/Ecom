using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public record UpdateProductCommand(Guid ProductID, Product Product) : IRequest<Product>;
    internal class UpdateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<UpdateProductCommand, Product>
    {
        public async Task<Product> Handle(UpdateProductCommand request,  CancellationToken cancellationToken)
        {
            return await productRepository.UpdateProductAsync(request.ProductID, request.Product);
        }
    }
}
