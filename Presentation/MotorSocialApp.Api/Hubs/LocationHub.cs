using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Api.Hubs
{
    public class LocationHub:Hub
    {

        public async Task AddLocation(ChatGroup chatGroup)
        {
            await Clients.All.SendAsync("AddLocation", chatGroup);
        }
    }
}
