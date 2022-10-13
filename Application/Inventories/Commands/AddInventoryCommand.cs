using System;
using Application.Core;
using MediatR;

namespace Application.Inventories
{
    public class AddInventoryCommand : IRequest<Result<Unit>>
    {
        public string InventoryId { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public List<string> Tags { get; set; }
    }
}