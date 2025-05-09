using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public record GetProductByIdQuery(Guid productId) : IRequest<Product>;
    internal class GetProductByIdQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductByIdQuery, Product>
    {
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductByIdAsync(request.productId);
        }
    }
}
