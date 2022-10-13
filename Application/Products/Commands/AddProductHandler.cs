using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using MediatR;

namespace Application.Inventories
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Result<Unit>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public AddProductHandler(IMediator mediator,
                                 IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var companyResult = await _mediator.Send(new AddCompanyCommand 
            { 
                CompanyPrefix = request.CompanyPrefix,
                CompanyName = request.CompanyName,
            });

            if(!companyResult.IsSuccess)
                return Result<Unit>.Failure(companyResult.Error);

            var product = new Product
            {
                CompanyPrefix = request.CompanyPrefix,
                ItemReference = request.ItemReference,
                ItemName = request.ItemName,
            };

            await _productRepository.AddProduct(product);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}