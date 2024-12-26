using Google.Apis.Auth.OAuth2;
using MotorSocialApp.Application.Interfaces.FirebaseNotificationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MotorSocialApp.Persistence.FirebaseNotificationServices
{
    public class FirebaseNotificationService : IFirebaseNotificationService
    {
        private readonly string _serviceAccountPath;
        private readonly string _projectId;

        public FirebaseNotificationService(string serviceAccountPath, string projectId)
        {
            _serviceAccountPath = serviceAccountPath;
            _projectId = projectId;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            GoogleCredential credential;
            using (var stream = new FileStream(_serviceAccountPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(new[] {
                        "https://www.googleapis.com/auth/userinfo.email",
        "https://www.googleapis.com/auth/firebase.database",
        "https://www.googleapis.com/auth/firebase.messaging" });
            }

            var accessToken = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
            return accessToken;
        }

        public async Task<bool> SendNotificationAsync(string deviceToken, string title, string body, Dictionary<string, string>? data = null)
        {
            var accessToken = await GetAccessTokenAsync();

            var payload = new
            {
                message = new
                {
                    token = deviceToken,
                    notification = new
                    {
                        title = title,
                        body = body
                    },
                    data=data
                }
            };

            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", accessToken);

                    var jsonPayload = JsonSerializer.Serialize(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var firebaseUrl = $"https://fcm.googleapis.com/v1/projects/{_projectId}/messages:send";
                    var response = await httpClient.PostAsync(firebaseUrl, content);

                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }



            }
        }
    }
}
