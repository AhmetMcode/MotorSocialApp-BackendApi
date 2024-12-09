using Microsoft.AspNetCore.SignalR;

namespace MotorSocialApp.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinGroup(string userId,string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }

        public async Task LeaveGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }
    }
}
