using System;
using System.Threading.Tasks;
using UIKit;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.iOS
{
	public partial class FriendsController : UITableViewController
	{
		readonly FriendViewModel friendViewModel = ServicesContainer.Resolve<FriendViewModel>();

		public FriendsController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var friendsTblSrce = new FriendsTableSource();
			TableView.Source = friendsTblSrce;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			try
			{
				Task.Run(async () =>
				{
					await friendViewModel.GetFriends();
					InvokeOnMainThread(() => TableView.ReloadData());
				});
			}
			catch (Exception ex)
			{
				var alert = UIAlertController.Create("Friends Failure", ex.Message, UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

				PresentViewController(alert, true, null);
			}
		}
	}
}