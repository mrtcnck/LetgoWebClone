using Letgo.BusinessLayer.Db.Abstract;
using Letgo.DataAccess.DbRepositories.Concrete;
using Letgo.Entities.Concrete;
using Letgo.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Letgo.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
        private readonly IChatHistoryManagerDb chatHistoryManager;
        private readonly UserManager<User> userManager;

        public ChatHub(IChatHistoryManagerDb chatHistoryManager, UserManager<User> userManager)
        {
            this.chatHistoryManager = chatHistoryManager;
            this.userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var userId = userManager.GetUserAsync(Context.User).Result.Id;
                _connections.Add(userId, Context.ConnectionId);
            }
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string message, string chatObjectId)
        {
            //if (_connections.GetConnections(receiverUserId).Count() <= 0)
            //{
            //    await Task.CompletedTask;
            //}

            //var targetUserConnectionId = _connections.GetConnections(receiverUserId).First();
            //await Clients.Client(targetUserConnectionId).SendAsync("ChatChannel", message);

            await AddChatHistory(message, chatObjectId);
        }

        private async Task AddChatHistory(string message, string chatObjectId)
        {
            var senderUserId = userManager.GetUserAsync(Context.User).Result.Id;

            await chatHistoryManager.Create(new ChatHistory
            {
                ChatObjectID = chatObjectId,
                UserId = senderUserId,
                Message = message,
                CreationDate = DateTime.Now.Date
            });
        }
    }
}
