
using System;
using Foundation;
using UIKit;
using XamChat.Core.Models;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.iOS
{
	public class FriendsTableSource : UITableViewSource
	{
		const string CellName = "FriendCell";

		readonly FriendViewModel friendViewModel = ServicesContainer.Resolve<FriendViewModel>();

		public EventHandler<EventArgs> DidSelectFriend;

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			User friend = friendViewModel.Friends[indexPath.Row];
			UITableViewCell cell = tableView.DequeueReusableCell(CellName);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellName);
				cell.AccessoryView = UIButton.FromType(UIButtonType.ContactAdd);
				cell.AccessoryView.UserInteractionEnabled = false;
			}

			cell.TextLabel.Text = friend.UserName;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return friendViewModel.Friends == null ? 0 : friendViewModel.Friends.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			DidSelectFriend?.Invoke(this, EventArgs.Empty);
		}
	}
}
