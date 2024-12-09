using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Api.Hubs
{
   
    public class ExploreHubService : Hub
    {
        // Yeni bir post eklendiğinde tüm istemcilere bildir.
        public async Task NewPost(Post post)
        {
            await Clients.All.SendAsync("ReceivePost", post);
        }

    }
}
