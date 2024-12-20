using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Interfaces.GoogleGeocode;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeocodeController : ControllerBase
    {
        private readonly IGoogleGeocodeService _geocodeService;

        public GeocodeController(IGoogleGeocodeService geocodeService)
        {
            _geocodeService = geocodeService;
        }
        [HttpPost]
        public async Task<IActionResult> GetAddressDetails( UserLastLocationValues location)
        {
            try
            {
                var addressDetails = await _geocodeService.GetFormattedAddressDetailsAsync(location.Lat,location.Lng);

                if (addressDetails == null)
                {
                    return NotFound("Adres bulunamadı.");
                }

                return Ok(addressDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
