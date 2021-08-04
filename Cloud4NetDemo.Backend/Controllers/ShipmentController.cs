using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud4NetDemo.Application.Features.Shipment.Command;
using Cloud4NetDemo.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cloud4NetDemo.Backend.Controllers
{
    [ApiController]
    [Route("ship")]
    public class ShipmentController : ControllerBase
    {

        private IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<ShipmentTrackerDto>> Post(ShipmentRequestDto request)
        {
            return Ok(await _mediator.Send(new ShipPackageCommand { Request = request }));
        }
    }
}