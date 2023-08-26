using Mc2.CureCost.Core.DTOs;
using Mc2.CureCost.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mc2.CureCost.Domain.Commands;
using Mc2.CureCost.Domain.Queries;


namespace Mc2.CureCost.Presentation.Server.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RequestController> _logger;

        public RequestController(IMediator mediator, ILogger<RequestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var query = new GetAllRequestsQuery();
                var Requests = await _mediator.Send(query);
                return Ok(Requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Requests.");
                return StatusCode(500, "An error occurred while retrieving Requests.");
            }
        }

        [HttpGet("{RequestId}")]
        [ActionName("GetRequestById")]
        public async Task<IActionResult> GetRequestById(int RequestId)
        {
            try
            {
                var query = new GetRequestByIdQuery { RequestId = RequestId };
                var Request = await _mediator.Send(query);

                if (Request == null)
                {
                    return NotFound($"Request with ID {RequestId} not found.");
                }

                return Ok(Request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the Request.");
                return StatusCode(500, "An error occurred while retrieving the Request.");
            }
        }

        [HttpPost]
        [ActionName("CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] RequestWriteDTO Request)
        {
            try
            {
                // Validate input data
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return BadRequest(errors);
                }

                var command = new CreateRequestCommand(Request.Firstname, Request.Lastname, Request.DateOfBirth, Request.PhoneNumber, Request.Email, Request.BankAccountNumber);
                var createdRequest = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetRequestById), new { RequestId = createdRequest.Id }, createdRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Request.");
                return StatusCode(500, "An error occurred while creating the Request.");
            }
        }
        [HttpPut("{RequestId}")]
        [ActionName("UpdateRequest")]
        public async Task<IActionResult> UpdateRequest(int RequestId, [FromBody] RequestWriteDTO Request)
        {
            try
            {
                var bankAccountNumber = new BankAccountNumber(Request.BankAccountNumber);

                var command = new UpdateRequestCommand(RequestId, Request.Firstname, Request.Lastname, Request.DateOfBirth, Request.PhoneNumber, Request.Email, bankAccountNumber);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Request.");
                return StatusCode(500, "An error occurred while updating the Request.");
            }
        }

        [HttpDelete("{RequestId}")]
        [ActionName("DeleteRequest")]
        public async Task<IActionResult> DeleteRequest(int RequestId)
        {
            try
            {
                var command = new DeleteRequestCommand(RequestId);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Request.");
                return StatusCode(500, "An error occurred while deleting the Request.");
            }
        }
    }
}