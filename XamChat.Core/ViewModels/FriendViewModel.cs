
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamChat.Core.Models;

namespace XamChat.Core.ViewModels
{
	public class FriendViewModel : BaseViewModel
	{
		public User[] Friends
		{
			get;
			private set;
		}

		public string UserName
		{
			get;
			set;
		}

		public async Task GetFriends()
		{
			if (settings.Usr == null)
			{
				throw new Exception("Not logged in.");
			}

			IsBusy = true;
			try
			{
				Friends = await service.GetFriends(settings.Usr.Id);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public async Task AddFriend()
		{
			if (settings.Usr == null)
			{
				throw new Exception("Not loggeed in");
			}

			if (string.IsNullOrEmpty(UserName))
			{
				throw new Exception("User name is blank");
			}

			IsBusy = true;
			try
			{
				var friend = await service.AddFriend(settings.Usr.Id, UserName);

				// Update our local list of friends.
				var friends = new List<User>();
				if (Friends != null)
				{
					friends.AddRange(Friends);
				}

				friends.Add(friend);
				Friends = friends.OrderBy(f => f.UserName).ToArray();
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
