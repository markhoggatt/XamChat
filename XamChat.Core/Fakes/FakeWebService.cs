
using System;
using System.Threading.Tasks;
using XamChat.Core.Contracts;
using XamChat.Core.Models;

namespace XamChat.Core.Fakes
{
	public class FakeWebService : IWebService
	{
		public int SleepDuration
		{
			get;
			set;
		}

		public FakeWebService()
		{
			SleepDuration = 1;
		}

		private Task Sleep()
		{
			return Task.Delay(SleepDuration);
		}

		public async Task<User> Login(string username, string password)
		{
			await Sleep();
			return new User { Id = "1", UserName = username };
		}

		public async Task<User> Register(User user)
		{
			await Sleep();
			return user;
		}

		public async Task<User[]> GetFriends(string userId)
		{
			await Sleep();
			return new[]
			{
				new User{Id = "2", UserName = "bobama"},
				new User{Id = "3", UserName = "blobloblaw"},
				new User{Id = "4", UserName = "gmichael"}
			};
		}

		public async Task<User> AddFriend(string userId, string username)
		{
			await Sleep();
			return new User { Id = "5", UserName = username };
		}

		public async Task<Conversation[]> GetConversations(string userId)
		{
			await Sleep();

			return new[]
			{
				new Conversation {Id = "1", UserId = "2", Username = "bobama", LastMessage = "Hmmm!"},
				new Conversation {Id = "1", UserId = "3", Username = "blobloblaw", LastMessage = "Have you seen the new film?"},
				new Conversation {Id = "1", UserId = "4", Username = "gmichael", LastMessage = "Eh?"}
			};
		}

		public async Task<Message[]> GetMessages(string conversationId)
		{
			await Sleep();

			return new[]
			{
				new Message {Id = "1", ConversationId = conversationId, UserId = "2", Text = "Hello.", Date = DateTime.Now.AddMinutes(-15)},
				new Message {Id = "2", ConversationId = conversationId, UserId = "1", Text = "Was ist loss?", Date = DateTime.Now.AddMinutes(-10)},
				new Message {Id = "3", ConversationId = conversationId, UserId = "2", Text = "Have you seen the new film?", Date = DateTime.Now.AddMinutes(-5)},
				new Message {Id = "4", ConversationId = conversationId, UserId = "1", Text = "It's marvelous.", Date = DateTime.Now}
			};
		}

		public async Task<Message> SendMessage(Message mesg)
		{
			await Sleep();
			return mesg;
		}
	}
}
