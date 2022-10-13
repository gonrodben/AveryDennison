using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Inventories;
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

        //[HttpGet]
        //public async Task<IActionResult> GetPatients([FromQuery] PatientParams param ){


        //    _logger.LogInformation("Get Patients executed at {date}", DateTime.UtcNow);

        //    var result = await Mediator.Send(new ListPatientsQuery{Params = param});
        //    return Result(result);
        //}


    }
}