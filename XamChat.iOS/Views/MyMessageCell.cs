
using System;
using XamChat.Core.Models;
using XamChat.iOS.Views;

namespace XamChat.iOS
{
	public partial class MyMessageCell : BaseMessageCell
	{
		public MyMessageCell(IntPtr handle) : base(handle)
		{
		}

		public override void Update(Message mesg)
		{
			base.Update(mesg);

			message.Text = mesg.Text;
		}
	}
}