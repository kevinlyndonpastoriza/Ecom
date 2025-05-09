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
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
    internal class GetProductsQueryHandler(IProductRepository  productRepository)
        : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductsAsync();
        }
    }
}
