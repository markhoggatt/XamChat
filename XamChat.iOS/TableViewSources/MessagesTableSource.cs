
using System;
using Foundation;
using UIKit;
using XamChat.Core.Contracts;
using XamChat.Core.Models;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;
using XamChat.iOS.Views;

namespace XamChat.iOS.TableViewSources
{
	public class MessagesTableSource : UITableViewSource
	{
		const string MyCellName = "MyCell";
		const string TheirCellName = "TheirCell";

		readonly MessageViewModel messageViewModel = ServicesContainer.Resolve<MessageViewModel>();
		readonly ISettings settings = ServicesContainer.Resolve<ISettings>();

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			Message message = messageViewModel.Messages[indexPath.Row];
			bool isMyMessage = message.UserId == settings.Usr.Id;
			var cell = tableView.DequeueReusableCell(isMyMessage ? MyCellName : TheirCellName) as BaseMessageCell;
			cell.Update(message);

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return messageViewModel.Messages == null ? 0 : messageViewModel.Messages.Length;
		}
	}
}
