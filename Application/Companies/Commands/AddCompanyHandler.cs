using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using MediatR;

namespace Application.Inventories
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, Result<Unit>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMediator _mediator;

        public AddCompanyHandler(IMediator mediator,
                                 ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
            this._mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                CompanyPrefix = request.CompanyPrefix,
                CompanyName = request.CompanyName,
            };

            await _companyRepository.AddCompany(company);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}