using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public record DeleteProductCommand(Guid ProductID) : IRequest<bool>;
    internal class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteProductAsync(request.ProductID);
        }
    }
}
