
using System;
using Foundation;
using UIKit;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.iOS
{
	public class ConversationsTableSource : UITableViewSource
	{
		const string CellName = "ConversationCell";
		readonly MessageViewModel messageViewModel = ServicesContainer.Resolve<MessageViewModel>();

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var conversation = messageViewModel.Conversations[indexPath.Row];
			var cell = tableView.DequeueReusableCell(CellName);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellName)
				{
					Accessory = UITableViewCellAccessory.DisclosureIndicator
				};
			}

			cell.TextLabel.Text = conversation.Username;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return messageViewModel.Conversations == null ? 0 : messageViewModel.Conversations.Length;
		}
	}
}
