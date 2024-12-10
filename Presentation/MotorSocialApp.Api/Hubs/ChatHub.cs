using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task CreateGroupChatConnection(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }

        public async Task BrokeGroupChatConnection(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }

        public async Task SendMessageToGroup(GroupChatMessage message)
        {
            await Clients.Group(message.GroupId.ToString()).SendAsync("ChatMessage",message.SenderUserName,message.Content,message.SentAt,message.SenderUserId);
        }

        public async Task CreateNewMessageGroup(ChatGroup chatGroup) {
            await Clients.All.SendAsync("ChatGroup",chatGroup);
        }

    }
}
