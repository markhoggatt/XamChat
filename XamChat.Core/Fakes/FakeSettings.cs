
using XamChat.Core.Contracts;
using XamChat.Core.Models;

namespace XamChat.Core.Fakes
{
	public class FakeSettings : ISettings
	{
		public User Usr
		{
			get;
			set;
		}

		public void Save()
		{

		}
	}
}
