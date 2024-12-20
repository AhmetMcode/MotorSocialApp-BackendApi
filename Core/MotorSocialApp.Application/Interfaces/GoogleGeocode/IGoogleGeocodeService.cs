using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Interfaces.GoogleGeocode
{
    public interface IGoogleGeocodeService
    {
        /// <summary>
        /// Google Geocoding API kullanarak latitude ve longitude değerine göre adres detaylarını getirir.
        /// </summary>
        /// <param name="latitude">Enlem (Latitude)</param>
        /// <param name="longitude">Boylam (Longitude)</param>
        /// <returns>Adres detaylarını içeren sözlük (Dictionary).</returns>
        Task<Dictionary<string, string>> GetFormattedAddressDetailsAsync(double latitude, double longitude);
    }
}
