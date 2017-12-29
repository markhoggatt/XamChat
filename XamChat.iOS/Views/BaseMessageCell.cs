
using System;
using UIKit;
using XamChat.Core.Models;

namespace XamChat.iOS.Views
{
	public class BaseMessageCell : UITableViewCell
	{
		public BaseMessageCell(IntPtr handle) : base(handle)
		{
		}

		public virtual void Update(Message mesg)
		{
		}
	}
}
