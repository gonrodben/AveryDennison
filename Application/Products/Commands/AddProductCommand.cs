using System;
using Application.Core;
using MediatR;

namespace Application.Inventories
{
    public class AddProductCommand : IRequest<Result<Unit>>
    {
        public ulong CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public ulong ItemReference { get; set; }
        public string ItemName { get; set; }
    }
}