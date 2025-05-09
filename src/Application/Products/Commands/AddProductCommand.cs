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
    public record AddProductCommand(Product Product) : IRequest<Product>;
    internal class AddProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<AddProductCommand, Product>
    {
        public async Task<Product> Handle(AddProductCommand request,  CancellationToken cancellationToken)
        {
            return await productRepository.AddProductAsync(request.Product);
        }
    }
}
