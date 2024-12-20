using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Persistence.GoogleGeocode
{
    using MotorSocialApp.Application.Interfaces.GoogleGeocode;
    using MotorSocialApp.Domain.Entities;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class GoogleGeocodeService : IGoogleGeocodeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "AIzaSyCWGyXIvxbhISOBjpbWalJuaK0Q9w445Co";

        public GoogleGeocodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<Dictionary<string, string>> GetFormattedAddressDetailsAsync(double latitude, double longitude)
        {
            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={ApiKey}";

            var response = await _httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Google API isteği başarısız oldu.");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            // JSON'u GeocodeResponse modeline deserialize et
            var geocodeResponse = JsonSerializer.Deserialize<GeocodeResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var result = geocodeResponse?.Results?.FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            // Address details çekmek için sözlük oluştur
            var addressDetails = new Dictionary<string, string>
        {
            { "formatted_address", result.FormattedAddress },
            { "latitude", result.Geometry.UserLastLocationValues.Lat.ToString() },
            { "longitude", result.Geometry.UserLastLocationValues.Lng.ToString() }
        };

            // AddressComponents içinden şehir, ülke ve posta kodunu al
            foreach (var component in result.AddressComponents)
            {
                if (component.Types.Contains("administrative_area_level_1")) // Şehir
                    addressDetails["city"] = component.LongName;

                if (component.Types.Contains("country")) // Ülke
                    addressDetails["country"] = component.LongName;

                if (component.Types.Contains("postal_code")) // Posta Kodu
                    addressDetails["postal_code"] = component.LongName;
            }

            return addressDetails;
        }
    }

}
