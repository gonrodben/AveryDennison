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
    public class ProductController : BaseApiController
    {
        protected ILogger<ProductController> _logger;
        
        public ProductController(ILogger<ProductController> logger)
        {
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductCommand createProductCommand)
        {
            _logger.LogInformation();

            var result = await Mediator.Send(createProductCommand);
            return HandleResult(result);
        }
    }
}