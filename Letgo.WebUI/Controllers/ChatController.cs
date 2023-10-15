using Letgo.BusinessLayer.API.Concrete;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.BusinessLayer.Db.Concrete;
using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Letgo.WebUI.Controllers
{
    [Authorize(Roles = "Member, Admin, Manager")]
    public class ChatController : Controller
    {
        private readonly IChatManagerDb chatManager;
        private readonly IChatHistoryManagerDb chatHistoryManager;
        private readonly UserManager<User> userManager;
        public ChatController(IChatManagerDb chatManager, IChatHistoryManagerDb chatHistoryManager, UserManager<User> userManager)
        {
            this.chatManager = chatManager;
            this.chatHistoryManager = chatHistoryManager;
            this.userManager = userManager;
        }

        public string getUserId()
        {
            var user = userManager.GetUserAsync(User).Result;
            return user.Id;
        }

        [Route("/mesajlarim")]
        public async Task<IActionResult> Chats()
        {
            try
            {
                var chats = await chatManager.GetAll(c => c.ReceiverId == getUserId() || c.SenderId == getUserId());
                return View(chats);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }

        [Route("/mesajlarim/detay/{ObjectID}")]
        public async Task<IActionResult> GetDetail(string ObjectID)
        {
            try
            {
                var chatDetails = await chatHistoryManager.GetAll(ch => ch.ChatObjectID == ObjectID);
                var chat = await chatManager.GetById(ObjectID);
                if (chat.SenderId == getUserId() || chat.ReceiverId == getUserId())
                {
                    return View(chat);
                }
                else
                {
                    return Redirect("/Identity/Account/AccessDenied");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatHistory chatHistory)
        {
            try
            {
                await chatHistoryManager.Create(chatHistory);
                return Redirect("~/mesajlarim/detay/" + chatHistory.ChatObjectID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateChat(string AdvertObjectID, string SenderId, string ReceiverId)
        {
            try
            {
                Chat chat = new()
                {
                    AdvertObjectID = AdvertObjectID,
                    SenderId = SenderId,
                    ReceiverId = ReceiverId
                };
                await chatManager.Create(chat);
                return Redirect("~/mesajlarim/detay/" + chat.ObjectID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
    }
}
