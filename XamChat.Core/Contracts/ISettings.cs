
using XamChat.Core.Models;

namespace XamChat.Core.Contracts
{
	public interface ISettings
	{
		User Usr
		{
			get;
			set;
		}

		void Save();
	}
}
