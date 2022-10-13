using System;
using Application.Core;
using MediatR;

namespace Application.Inventories
{
    public class AddCompanyCommand : IRequest<Result<Unit>>
    {
        public ulong CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
    }
}