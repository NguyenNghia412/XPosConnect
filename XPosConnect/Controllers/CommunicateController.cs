using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XPosConnect.Lib;
using XPosConnect.Lib.Dto.Communicate;

namespace XPosConnect.Controllers
{
    [Route("api/communicate")]
    [ApiController]
    public class CommunicateController : ControllerBase
    {
        private readonly XPosConnectService _service;
        private readonly ILogger<CommunicateController> _logger;

        public CommunicateController(ILogger<CommunicateController> logger)
        {
            _service = new XPosConnectService();
            _logger = logger;
        }

        [HttpPost("show-qr")]
        public IActionResult GenerateQr([FromBody] GenerateQrDto dto)
        {
            _logger.LogInformation($"Received request to generate QR code with data: dto={JsonSerializer.Serialize(dto)}");
            try
            {
                _service.GenQrCode(dto);

                _logger.LogInformation("QR code generated successfully.");

                return Ok(new
                {
                    Success = true,
                    Message = "QR Code generated successfully."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "Internal Server Error",
                    message = ex.Message
                });
            }            
        }
    }
}
