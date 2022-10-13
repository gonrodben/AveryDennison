using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Inventories;
using Application.Inventories.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class InventoryController : BaseApiController
    {
        protected ILogger<InventoryController> _logger;
        
        public InventoryController(ILogger<InventoryController> logger)
        {
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory(AddInventoryCommand addInventoryCommand)
        {
            var result = await Mediator.Send(addInventoryCommand);
            return HandleResult(result);
        }

        [HttpGet("CountByProductAndInventory")]
        public async Task<IActionResult> GetCountByProductAndInventory(CountByProductAndInventory query)
        {
            var result = await Mediator.Send(query);
            return HandleResult(result);
        }

        [HttpGet("GetCountByProductAndDate")]
        public async Task<IActionResult> GetCountByProductAndDate(CountByProductAndDate query)
        {
            var result = await Mediator.Send(query);
            return HandleResult(result);
        }

        [HttpGet("GetCountByCompany")]
        public async Task<IActionResult> GetCountByCompany(CountByCompany query)
        {
            var result = await Mediator.Send(query);
            return HandleResult(result);
        }

    }
}