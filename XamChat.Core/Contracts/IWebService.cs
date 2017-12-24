
using System.Threading.Tasks;
using XamChat.Core.Models;

namespace XamChat.Core.Contracts
{
	public interface IWebService
	{
		Task<User> Login(string userName, string password);
		Task<User> Register(User usr);
		Task<User[]> GetFriends(string userId);
		Task<User> AddFriend(string userId, string username);
		Task<Conversation[]> GetConversations(string userId);
		Task<Message[]> GetMessages(string conversationId);
		Task<Message> SendMessage(Message mesg);
	}
}
