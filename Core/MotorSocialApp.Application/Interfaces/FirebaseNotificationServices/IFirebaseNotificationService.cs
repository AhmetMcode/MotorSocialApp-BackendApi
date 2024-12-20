
using System.Threading.Tasks;
namespace MotorSocialApp.Application.Interfaces.FirebaseNotificationServices
{
    public interface IFirebaseNotificationService
    {
        /// <summary>
        /// Firebase Service Account üzerinden Access Token alır.
        /// </summary>
        Task<string> GetAccessTokenAsync();

        /// <summary>
        /// Belirtilen cihaza Firebase bildirimi gönderir.
        /// </summary>
        Task<bool> SendNotificationAsync(string deviceToken, string title, string body, Dictionary<string, string>? data = null);
    }

}



